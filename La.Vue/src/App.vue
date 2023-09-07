<template>
  <el-config-provider :locale="locale" :size="size">
    <router-view />
  </el-config-provider>
</template>
<script setup>
  import useUserStore from './store/modules/user'
  import useAppStore from './store/modules/app'
  import { ElConfigProvider } from 'element-plus'
  import zh from 'element-plus/dist/locale/zh-cn.mjs' // 中文语言
  import tw from 'element-plus/dist/locale/zh-tw.mjs' //繁体
  import ja from 'element-plus/dist/locale/ja.mjs' //繁体
  import en from 'element-plus/dist/locale/en.mjs' // 英文语言

  import defaultSettings from '@/settings'
  const { proxy } = getCurrentInstance()

  const token = computed(() => {
    return useUserStore().userId
  })

  const lang = computed(() => {
    return useAppStore().lang
  })
  const locale = ref(zh)
  const size = ref(defaultSettings.defaultSize)

  size.value = useAppStore().size
  watch(
    token,
    (val) => {
      if (val) {
        proxy.signalr.start().then(async (res) => {
          if (res) {
            await proxy.signalr.SR.invoke('logOut')
          }
        })
      }
    },
    {
      immediate: true,
      deep: true
    }
  )
  watch(
    lang,
    (val) => {
      if (val == 'zh-cn') {
        locale.value = zh
      } else if (val == 'zh-tw') {
        locale.value = tw
      } else if (val == 'ja') {
        locale.value = ja
      } else if (val == 'en') {
        locale.value = en
      } else {
        locale.value = zh
      }
    },
    {
      immediate: true
    }
  )
  console.log('💎源码地址: https://github.com/Lean365/LaplaceNet')
  console.log('🔰官方文档：https://laplacenet.github.io/')
  console.log('🎀打赏作者：https://laplacenet.github.io/docs/others/donate.html')

</script>