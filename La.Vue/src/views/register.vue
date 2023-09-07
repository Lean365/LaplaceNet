<template>
  <!-- <animationBackground></animationBackground> -->
  <starBackground></starBackground>
  <div class="register">
    <div class="drawer-item" style="display: flex; justify-content: flex-start">
      <img :src='imgsrc' class="image" />
      <h6 class="slogan">{{ $t('layout.slogan') }}</h6>
    </div>
    <LangSelect :title="$t('layout.multiLanguage')" class="v-tag" />
    <el-form ref="registerFormRef" :model="registerForm" :rules="registerRules" class="register-form">
      <h3 class="title">{{ title }}</h3>

      <el-form-item prop="username">
        <el-input v-model="registerForm.username" type="text" auto-complete="off" :placeholder="$t('plogin.account')">
          <template #prefix>
            <svg-icon name="user" />
          </template>
        </el-input>
      </el-form-item>
      <el-form-item prop="password">
        <el-input v-model="registerForm.password" type="password" auto-complete="off"
          :placeholder="$t('plogin.password')" @keyup.enter.native="handleRegister">
          <template #prefix>
            <svg-icon name="password" />
          </template>
        </el-input>
      </el-form-item>
      <el-form-item prop="confirmPassword">
        <el-input v-model="registerForm.confirmPassword" type="password" auto-complete="off"
          :placeholder="$t('plogin.confirmPassword')" @keyup.enter.native="handleRegister">
          <template #prefix>
            <svg-icon name="password" />
          </template>
        </el-input>
      </el-form-item>
      <el-form-item prop="code" v-if="captchaOnOff">
        <el-input v-model="registerForm.code" auto-complete="off" :placeholder="$t('plogin.captcha')" style="width: 63%"
          @keyup.enter.native="handleRegister">
          <template #prefix>
            <svg-icon name="validCode" />
          </template>
        </el-input>
        <div class="register-code ml10">
          <img :src="codeUrl" @click="getCode" class="register-code-img" />
        </div>
      </el-form-item>
      <el-form-item style="width: 100%">
        <el-button :loading="loading" type="primary" size="large" style="width: 100%"
          @click.native.prevent="handleRegister">
          <span v-if="!loading">{{ $t('plogin.registerSuccess') }}</span>
          <span v-else>{{ $t('plogin.underRegistration') }}</span>
        </el-button>
        <div style="float: right">
          <router-link class="link-type" :to="'/login'">{{ $t('plogin.existingUsers') }}</router-link>
        </div>
      </el-form-item>
    </el-form>
    <!--  底部  -->
    <div class="el-register-footer">
      <div v-html="defaultSettings.copyright"></div>
    </div>
  </div>
</template>

<script setup name="register">
  //import animationBackground from '@/views/components/animationBackground-nasa.vue'
  import starBackground from '@/views/components/starBackground.vue'
  import { getCodeImg, register } from '@/api/system/login'
  import LangSelect from '@/components/LangSelect/index.vue'
  import defaultSettings from '@/settings'
  import { ElMessageBox } from 'element-plus'
  // 获取当前组件的上下文，下面两种方式都能获取到组件的上下文。
  //const { ctx } = getCurrentInstance();  //  方式一，这种方式只能在开发环境下使用，生产环境下的ctx将访问不到
  //const { proxy } = getCurrentInstance();  //  方式二，此方法在开发环境以及生产环境下都能放到组件上下文对象（推荐）
  // ctx 中包含了组件中由ref和reactive创建的响应式数据对象,以及以下对象及方法;
  const imgsrc = 'src/assets/logo/login.png'
  const { proxy } = getCurrentInstance()
  const router = useRouter()
  const codeUrl = ref('')
  const registerForm = reactive({
    username: '',
    password: '',
    confirmPassword: '',
    code: '',
    uuid: '',
  })

  const registerFormRef = ref(null)
  const loading = ref(false)
  const captchaOnOff = ref(true)
  const equalToPassword = (rule, value, callback) => {
    if (registerForm.password !== value) {
      callback(new Error(proxy.$t('plogin.IncPassword')))
    } else {
      callback()
    }
  }
  const registerRules = reactive({
    username: [
      { required: true, trigger: 'blur', message: proxy.$t('plogin.enterAccount') },
      {
        min: 2,
        max: 20,
        message: proxy.$t('plogin.enterAccount'),
        trigger: 'blur',
      },
    ],
    password: [
      {
        required: true, trigger: 'blur', message: proxy.$t('plogin.enterPassword')
      },
      {
        min: 5,
        max: 20,
        message: proxy.$t('plogin.lengthPassword'),
        trigger: 'blur',
      },
    ],
    confirmPassword: [
      {
        required: true, trigger: 'blur', message: proxy.$t('plogin.againPassword')
      },
      { required: true, validator: equalToPassword, trigger: 'blur' },
    ],
    code: [{
      required: true, trigger: 'change', message: proxy.$t('plogin.enterCaptcha')
    }],
  })
  const copyRight = computed(() => {
    return defaultSettings.copyright
  })
  const title = computed(() => {
    return defaultSettings.title
  })

  function getCode() {
    getCodeImg().then((res) => {
      codeUrl.value = 'data:image/gif;base64,' + res.data.img
      registerForm.uuid = res.data.uuid
      // this.$forceUpdate()
    })
  }
  function handleRegister() {
    proxy.$refs['registerFormRef'].validate((valid) => {
      if (valid) {
        loading.value = true
        register(registerForm)
          .then((res) => {
            if (res.code == 200) {
              const username = registerForm.username
              ElMessageBox.alert("<font color='red'>" + proxy.$t('plogin.congratulationsAccount') + username + proxy.$t('plogin.successfulAccount') + '</font>', proxy.$t('plogin.systemPrompt'), {
                dangerouslyUseHTMLString: true,
                type: 'success',
              })
                .then(() => {
                  router.push('/login')
                })
                .catch(() => { })
            }
          })
          .catch(() => {
            loading.value = false
            if (captchaOnOff.value) {
              getCode()
            }
          })
      }
    })
  }
  getCode()
</script>

<style rel="stylesheet/scss" lang="scss">
  .register {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    background: radial-gradient(200% 100% at bottom center, #333366, #99ccff, #003366);
    background: radial-gradient(220% 105% at top center, #003366 10%, #99ccff 40%, #99ccff 65%, #333366);
  }

  .title {
    margin: 0px auto 30px auto;
    text-align: center;
    color: #fff;
  }

  .v-tag {
    margin: auto;
    border-radius: 5px;
    top: 20px;
    right: 20px;
    text-align: center;
    position: absolute;
    margin-left: 0;
    width: 32px;
    height: 24px;


    /* 翡翠色(#3de1ad)：1，翡翠鸟羽毛的青绿色。2，翡翠宝石的颜色。//顶部补白 （注：C-Y≥30 的系列色彩，多与白色配合以体现清新明丽感觉，与黑色配合效果不好：该色个性柔弱，会被黑色牵制） */

    background-color: #6eccad;

  }

  .register-form {
    border-radius: 6px;
    /* background: rgba(255, 255, 255, 0.3); */
    background-color: hsla(205, 80%, 71%, 0.3);
    width: 310px;
    padding: 25px 15px 5px 15px;

    .el-input {
      height: 38px;

      input {
        height: 38px;
      }
    }

    .input-icon {
      height: 39px;
      width: 14px;
      margin-left: 2px;
    }
  }

  .register-tip {
    font-size: 13px;
    text-align: center;
    color: #bfbfbf;
  }

  .register-code {
    width: 33%;
    height: 38px;
    float: right;

    img {
      cursor: pointer;
      vertical-align: middle;
    }
  }

  .el-register-footer {
    height: 40px;
    line-height: 40px;
    position: fixed;
    bottom: 0;
    width: 100%;
    text-align: center;
    color: #fff;
    font-family: Arial;
    font-size: 12px;
    letter-spacing: 1px;
  }

  .drawer-item {
    position: absolute;
    left: 50px;
    top: 50px;
    padding: 0px 10px 5px;

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

  }

  .register-code-img {
    height: 38px;
  }
</style>