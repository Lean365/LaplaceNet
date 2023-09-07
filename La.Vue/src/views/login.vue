<template>
  <videoBackground></videoBackground>
  <LangSelect :title="$t('layout.multiLanguage')" class="langSet" />
  <div class="login">
    <div class="drawer-item" style="display: flex; justify-content: flex-start">
      <img :src='imgsrc' class="image" />
      <h6 class="slogan">{{ $t('layout.slogan') }}</h6>
    </div>

    <el-form ref="loginRef" :model="loginForm" :rules="loginRules" class="login-form">

      <h3 class="title">{{ defaultSettings.title }}</h3>

      <el-form-item prop="username">
        <el-input v-model="loginForm.username" type="text" auto-complete="off" :placeholder="$t('plogin.account')">
          <template #prefix>
            <svg-icon name="user" class="input-icon" />
          </template>
        </el-input>
      </el-form-item>
      <el-form-item prop="password">
        <el-input v-model="loginForm.password" type="password" auto-complete="off" :placeholder="$t('plogin.password')"
          @keyup.enter="handleLogin">
          <template #prefix>
            <svg-icon name="password" class="input-icon" />
          </template>
        </el-input>
      </el-form-item>
      <el-form-item prop="code" v-if="captchaOnOff != 'off'">
        <el-input v-model="loginForm.code" auto-complete="off" :placeholder="$t('plogin.captcha')" style="width: 63%"
          @keyup.enter="handleLogin">
          <template #prefix>
            <svg-icon name="validCode" class="input-icon" />
          </template>
        </el-input>
        <div class="login-code">
          <img :src="codeUrl" @click="getCode" class="login-code-img" />
        </div>
      </el-form-item>
      <div style="display: flex; justify-content: space-between">
        <el-checkbox v-model="loginForm.rememberMe">{{ $t('plogin.rememberMe') }}</el-checkbox>

      </div>
      <el-form-item style="width: 100%">
        <el-button :loading="loading" size="default" type="primary" style="width: 100%" @click.prevent="handleLogin">
          <span v-if="!loading">{{ $t('plogin.btnLogin') }}</span>
          <span v-else>{{ $t('layout.loggingIn') }}</span>
        </el-button>
      </el-form-item>
      <div style="display: flex; justify-content: space-between">
        <span style="font-size: 14px">
          <span @click="handleForgetPwd()" class="forget-pwd">{{$t('plogin.forgotPwd')}}</span>
        </span>
        <span style="font-size: 14px">
          <router-link class="link-type" :to="'/register'">
            {{ $t('plogin.register') }}
          </router-link>
        </span>
      </div>

      <div class="other-login" v-if="defaultSettings.showOtherLogin">
        <el-divider>{{ $t('plogin.otherLoginWay') }}</el-divider>
        <span @click="onAuth('GITHUB')" title="github"><svg-icon name="github" className="login-icon"></svg-icon></span>
        <span @click="onAuth('GITEE')" title="gitee"><svg-icon name="gitee" className="login-icon"></svg-icon></span>
      </div>

    </el-form>

    <!--  底部  -->
    <div class="el-login-footer">
      <div v-html="defaultSettings.copyright"></div>
    </div>
  </div>

</template>

<script setup name="login">
  import { getCodeImg } from '@/api/system/login'
  import Cookies from 'js-cookie'
  import { encrypt, decrypt } from '@/utils/jsencrypt'
  import defaultSettings from '@/settings'
  import particlesBackground from '@/views/components/particlesBackground.vue'
  import LangSelect from '@/components/LangSelect/index.vue'
  import useUserStore from '@/store/modules/user'
  import videoBackground from '@/views/components/videoBackground.vue'
  import { resetUserPwd } from '@/api/system/user'
  const imgsrc = 'src/assets/logo/login.png'
  const userStore = useUserStore()
  const router = useRouter()
  const route = useRoute()
  const { proxy } = getCurrentInstance()

  const loginForm = ref({
    username: 'admin',
    password: '123456',
    rememberMe: false,
    code: '',
    uuid: ''
  })
  const host = window.location.host
  const loginRules = {
    username: [{ required: true, trigger: 'blur', message: proxy.$t('plogin.enterAccount') }],
    password: [{ required: true, trigger: 'blur', message: proxy.$t('plogin.enterPassword') }],
    code: [{ required: true, trigger: 'change', message: proxy.$t('plogin.enterCaptcha') }]
  }

  const codeUrl = ref('')
  const loading = ref(false)
  // 验证码开关
  const captchaOnOff = ref('')
  // 注册开关
  const register = ref(false)
  const redirect = ref()
  redirect.value = route.query.redirect

  function handleLogin() {
    proxy.$refs.loginRef.validate((valid) => {
      if (valid) {
        loading.value = true
        // 勾选了需要记住密码设置在cookie中设置记住用户名和密码
        if (loginForm.value.rememberMe) {
          Cookies.set('username', loginForm.value.username, { expires: 30, path: host })
          Cookies.set('password', encrypt(loginForm.value.password), { expires: 30, path: host })
          Cookies.set('rememberMe', loginForm.value.rememberMe, { expires: 30, path: host })
        } else {
          // 否则移除
          Cookies.remove('username')
          Cookies.remove('password')
          Cookies.remove('rememberMe')
        }
        // 调用action的登录方法
        userStore
          .login(loginForm.value)
          .then(() => {
            proxy.$modal.msgSuccess(proxy.$t('plogin.loginSuccess'))
            router.push({ path: redirect.value || '/' })
          })
          .catch((error) => {
            console.error(error)
            proxy.$modal.msgError(error.msg)
            loading.value = false
            // 重新获取验证码
            if (captchaOnOff.value) {
              getCode()
            }
          })
      }
    })
  }

  function getCode() {
    getCodeImg().then((res) => {
      codeUrl.value = 'data:image/gif;base64,' + res.data.img
      loginForm.value.uuid = res.data.uuid
      captchaOnOff.value = res.data.captchaOff
    })
  }

  function getCookie() {
    const username = Cookies.get('username')
    const password = Cookies.get('password')
    const rememberMe = Cookies.get('rememberMe')
    loginForm.value = {
      username: username === undefined ? loginForm.value.username : username,
      password: password === undefined ? loginForm.value.password : decrypt(password),
      rememberMe: rememberMe === undefined ? false : Boolean(rememberMe)
    }
  }
  function onAuth(type) {
    userStore.setAuthSource(type)

    switch (type) {
      default:
        window.location.href = import.meta.env.VITE_APP_BASE_API + '/auth/Authorization?authSource=' + type
        break
    }
  }
  // function handleForgetPwd() {
  //   proxy.$modal.msg('请联系管理员')
  // }

  /** 重置密码按钮操作 */
  function handleForgetPwd() {
    proxy.$modal.msgError(proxy.$t('plogin.contactAdmin'))
  }
  getCode()
  getCookie()
</script>

<style lang="scss" scoped>
  @import '@/assets/styles/login.scss';

  .forget-pwd {
    color: #ccc;
    margin-right: 10px;
    cursor: pointer;
  }

  .login-icon {
    width: 30px;
    height: 30px;
    margin-right: 20px;
    cursor: pointer;
  }

  .other-login {
    padding: 0px 10px 5px;
  }

  .drawer-item {
    position: absolute;
    left: 50px;
    top: 50px;
    padding: 0px 10px 5px;
  }

  .image {
    width: 5%;
    height: 5%;
    padding: 0px 10px 5px;

  }

  .slogan {
    position: absolute;
    left: 50px;
    top: -20px;
    width: 105%;
    height: 105%;
    padding: 0px 10px 5px;
    color: #304156;

  }

  .langSet {
    margin: auto;
    border-radius: 5px;
    text-align: center;
    width: 32px;
    height: 24px;
    background-color: #6eccad;
    //padding: 2px;
  }
</style>