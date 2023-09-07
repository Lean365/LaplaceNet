<!--
 * @Descripttion: (面包屑/页面路径)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-01-15)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-01-15)
-->
<template>

  <el-breadcrumb class="app-breadcrumb" separator="/">
    <!-- <transition-group name="breadcrumb"> -->
    <el-breadcrumb-item v-for="(item, index) in levelList" :key="item.path">
      <span v-if="item.redirect === 'noRedirect' || index == levelList.length - 1" class="no-redirect">
        {{ $t(item.meta.titleKey) }}
      </span>
      <span v-else @click.prevent="handleLink(item)" style="cursor: pointer">
        {{ $t(item.meta.titleKey) }}
      </span>
    </el-breadcrumb-item>
    <!-- </transition-group> -->

  </el-breadcrumb>

</template>

<script setup>
  const route = useRoute()
  const router = useRouter()
  const levelList = ref([])
  //meta.title: 'title'                  // 设置该路由在侧边栏和面包屑中展示的名字
  //meta.titleKey: '',                   //国际和翻译key值，如果不为空将使用i18n
  //Breadcrumb 面包屑(显示当前页面的路径，快速返回之前的任意页面)
  function getBreadcrumb() {
    // only show routes with meta.title
    let matched = route.matched.filter((item) => item.meta && item.meta.titleKey)
    const first = matched[0]
    // 判断是否为首页
    if (!isDashboard(first)) {
      matched = [{ path: '/index', meta: { title: 'menu.home' } }].concat(matched)
    }

    levelList.value = matched.filter((item) => item.meta && item.meta.titleKey && item.meta.breadcrumb !== false)
  }

  function isDashboard(route) {
    const name = route && route.name
    if (!name) {
      return false
    }
    //return name.trim().toLocaleLowerCase() === 'Index'.toLocaleLowerCase()
    return name.trim() === 'Index'
  }
  function handleLink(item) {
    const { redirect, path } = item
    if (redirect) {
      router.push(redirect)
      return
    }
    router.push(path)
  }

  watchEffect(() => {
    // if you go to the redirect page, do not update the breadcrumbs
    if (route.path.startsWith('/redirect/')) {
      return
    }
    getBreadcrumb()
  })
  getBreadcrumb()
</script>

<style lang="scss" scoped>
  .app-breadcrumb.el-breadcrumb {
    display: inline-block;
    font-size: 14px;
    line-height: 50px;
    margin-left: 8px;

    .no-redirect {
      color: #97a8be;
      cursor: text;
    }
  }

  .mobile .app-breadcrumb.el-breadcrumb {
    display: none;
  }
</style>