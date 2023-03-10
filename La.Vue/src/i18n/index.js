import { createI18n } from 'vue-i18n'
// import useAppStore from '@/store/modules/app'
import { listLangByLocale } from '@/api/system/commonLang'
import jsCookie from 'js-cookie'
const language = computed(() => {
  // return useAppStore().lang
  return jsCookie.get('lang') || 'zh-cn'
})
// 导入语言资源
import zh from './lang/zh-cn.json'//中文
import en from './lang/en.json'//英文
import ja from './lang/ja.json'//日文

// 登入页面
import pageLoginZh from './pages/login/zh-cn.json'//中文
import pageLoginEn from './pages/login/en.json'//英文
import pageLoginJa from './pages/login/ja.json'//日文


// 菜单页面
import pagemenuZh from './pages/menu/zh-cn'//中文
import pagemenuEn from './pages/menu/en'//英文
import pagemenuJa from './pages/menu/ja'//日文

// 部门页面
import pagedeptZh from './pages/dept/zh-cn'//中文
import pagedeptEn from './pages/dept/en'//英文
import pagedeptJa from './pages/dept/ja'//日文



const i18n = createI18n({
  // 全局注入 $t 函数
  globalInjection: true,
  fallbackLocale: 'zh-cn',
  locale: language.value, //默认选择的语言 
  legacy: false, // 使用 Composition API 模式，则需要将其设置为false
  messages: {
    'zh-cn': {
      ...zh,
      ...pageLoginZh,
      ...pagemenuZh,
      ...pagedeptZh
    },
    'en': {
      ...en,
      ...pageLoginEn,
      ...pagemenuEn,
      ...pagedeptEn
    },
    'ja': {
      ...ja,
      ...pageLoginJa,
      ...pagemenuJa,
      ...pagedeptJa
    },

    //... 在这里添加其他语言支持
  }
})

const loadLocale = () => {
  listLangByLocale(language.value).then(res => {
    const { code, data } = res
    if (code == 200) {
      i18n.global.mergeLocaleMessage(language.value, data)
    }
  })
}
loadLocale()
export default i18n;