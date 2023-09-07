import { createI18n } from 'vue-i18n'
// import useAppStore from '@/store/modules/app'
import { listLangByLocale } from '@/api/system/commonlang.js'
import defaultSettings from '@/settings'
import cache from '@/plugins/cache'
const language = computed(() => {
  // return useAppStore().lang
  return cache.local.get('lang') || defaultSettings.defaultLang
})

import Cn from './lang/zh-cn.json'
import Tw from './lang/zh-tw.json'
import Ja from './lang/ja.json'
import En from './lang/en.json'

//登录页面
import pageAboutCn from './pages/about/zh-cn.json'
import pageAboutTw from './pages/about/zh-tw.json'
import pageAboutJa from './pages/about/ja.json'
import pageAboutEn from './pages/about/en.json'
//部门页面
import pageDeptCn from './pages/dept/zh-cn.json'
import pageDeptTw from './pages/dept/zh-tw.json'
import pageDeptJa from './pages/dept/ja.json'
import pageDeptEn from './pages/dept/en.json'
//代码生成页面
import pageGenCn from './pages/gen/zh-cn.json'
import pageGenTw from './pages/gen/zh-tw.json'
import pageGenJa from './pages/gen/ja.json'
import pageGenEn from './pages/gen/en.json'
//语言页面
import pageLangCn from './pages/lang/zh-cn.json'
import pageLangTw from './pages/lang/zh-tw.json'
import pageLangJa from './pages/lang/ja.json'
import pageLangEn from './pages/lang/en.json'

//登录页面
import pageLoginCn from './pages/login/zh-cn.json'
import pageLoginTw from './pages/login/zh-tw.json'
import pageLoginJa from './pages/login/ja.json'
import pageLoginEn from './pages/login/en.json'

// 菜单页面
import pageMenuCn from './pages/menu/zh-cn.json'
import pageMenuTw from './pages/menu/zh-tw.json'
import pageMenuJa from './pages/menu/ja.json'
import pageMenuEn from './pages/menu/en.json'
//在线页面
import pageOnlineCn from './pages/online/zh-cn.json'
import pageOnlineTw from './pages/online/zh-tw.json'
import pageOnlineJa from './pages/online/ja.json'
import pageOnlineEn from './pages/online/en.json'
//角色页面
import pageRoleCn from './pages/role/zh-cn.json'
import pageRoleTw from './pages/role/zh-tw.json'
import pageRoleJa from './pages/role/ja.json'
import pageRoleEn from './pages/role/en.json'
//Tabs标签页面
import pageTabsCn from './pages/tabs/zh-cn.json'
import pageTabsTw from './pages/tabs/zh-tw.json'
import pageTabsJa from './pages/tabs/ja.json'
import pageTabsEn from './pages/tabs/en.json'
//上传页面
import pageUploadCn from './pages/upload/zh-cn.json'
import pageUploadTw from './pages/upload/zh-tw.json'
import pageUploadJa from './pages/upload/ja.json'
import pageUploadEn from './pages/upload/en.json'
//用户页面
import pageUserCn from './pages/user/zh-cn.json'
import pageUserTw from './pages/user/zh-tw.json'
import pageUserJa from './pages/user/ja.json'
import pageUserEn from './pages/user/en.json'
//欢迎页面
import pageWelcomeCn from './pages/welcome/zh-cn.json'
import pageWelcomeTw from './pages/welcome/zh-tw.json'
import pageWelcomeJa from './pages/welcome/ja.json'
import pageWelcomeEn from './pages/welcome/en.json'


const i18n = createI18n({
  // 全局注入 $t 函数
  globalInjection: true,
  fallbackLocale: 'zh-cn',
  locale: language.value, //默认选择的语言
  legacy: false, // 使用 Composition API 模式，则需要将其设置为false
  messages: {
    'zh-cn': {
      ...Cn,
      ...pageAboutCn,
      ...pageDeptCn,
      ...pageGenCn,
      ...pageLangCn,
      ...pageLoginCn,
      ...pageMenuCn,
      ...pageOnlineCn,
      ...pageRoleCn,
      ...pageTabsCn,
      ...pageUploadCn,
      ...pageUserCn,
      ...pageWelcomeCn,

    },
    'zh-tw': {
      ...Tw,
      ...pageAboutTw,
      ...pageDeptTw,
      ...pageGenTw,
      ...pageLangTw,
      ...pageLoginTw,
      ...pageMenuTw,
      ...pageOnlineTw,
      ...pageRoleTw,
      ...pageTabsTw,
      ...pageUploadTw,
      ...pageUserTw,
      ...pageWelcomeTw,
    },
    'ja': {
      ...Ja,
      ...pageAboutJa,
      ...pageDeptJa,
      ...pageGenJa,
      ...pageLangJa,
      ...pageLoginJa,
      ...pageMenuJa,
      ...pageOnlineJa,
      ...pageRoleJa,
      ...pageTabsJa,
      ...pageUploadJa,
      ...pageUserJa,
      ...pageWelcomeJa,
    },
    en: {
      ...En,
      ...pageAboutEn,
      ...pageDeptEn,
      ...pageGenEn,
      ...pageLangEn,
      ...pageLoginEn,
      ...pageMenuEn,
      ...pageOnlineEn,
      ...pageRoleEn,
      ...pageTabsEn,
      ...pageUploadEn,
      ...pageUserEn,
      ...pageWelcomeEn,
    }
    //... 在这里添加其他语言支持
  }
})

const loadLocale = () => {
  listLangByLocale(language.value).then((res) => {
    const { code, data } = res
    if (code == 200) {
      i18n.global.mergeLocaleMessage(language.value, data)
    }
  })
}
loadLocale()
export default i18n
