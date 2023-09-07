<template>
  <div>

    <div>
      <el-card>
        <template #header>
          <div>
            <el-icon>
              <DArrowRight />
            </el-icon>
            <h8>{{ $t('layout.shortCut') }}</h8>
          </div>
        </template>

        <el-row :gutter="24" type="flex">
          <el-col v-for="(card, key) in toolCards" :key="key" :span="2" :xs="8" @click="toTarget(card.name)">
            <el-card shadow="hover" style="cursor:pointer;text-align: center;">
              <div style=" height: 100%;border-radius: 50%;">
                <div @click="navigateToPage( card.url)" :style="{ backgroundColor: card.bg  }"
                  style="border-radius: 50%;">
                  <el-icon :style="{ backgroundColor: card.bg  }" style="height: 64px; width: 64px;border-radius: 50%;">
                    <component :is="card.icon" :style="{ color: card.color }"
                      style="height: 32px; width: 32px;border-radius: 50%;" />
                  </el-icon>
                </div>

                <br>{{ card.label }}
              </div>
            </el-card>
          </el-col>

        </el-row>

      </el-card>
      <!-- <div class="quick-entrance-title"></div> -->
    </div>
    <panel-group @handleSetLineChartData="handleSetLineChartData" />

    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="24">
        <div class="chart-wrapper">
          <line-chart :chart-data="lineChartData" :key="dataType" />
        </div>
      </el-col>
    </el-row>


  </div>
</template>

<script setup name="index">
  import PanelGroup from './dashboard/PanelGroup'
  import LineChart from './dashboard/LineChart'
  import RaddarChart from './dashboard/RaddarChart'
  import PieChart from './dashboard/PieChart'
  import BarChart from './dashboard/BarChart'
  import WordCloudChat from './dashboard/WordCloud.vue'

  import dayjs from 'dayjs'

  import useUserStore from '@/store/modules/user'
  import useSocketStore from '@/store/modules/socket'
  import { useRouter } from 'vue-router';

  const { proxy } = getCurrentInstance()
  const userInfo = computed(() => {
    return useUserStore().userInfo
  })
  const currentTime = computed(() => {
    return proxy.parseTime(new Date())
  })
  const onlineUsers = computed(() => {
    return useSocketStore().onlineUsers
  })
  // 使用 useRouter 获取路由实例
  const router = useRouter();
  // 声明组件局部状态和方法
  const navigateToPage = (page) => {
    // 使用路由实例的 push 方法进行页面导航
    router.push(page);
  }
  const toolCards = ref([
    {
      label: proxy.$t('menu.systemUser'),
      icon: 'Avatar',
      name: 'user',
      color: '#8491c3',
      bg: 'rgba(65,105,225,.3)',//皇家蓝
      url: 'system/user'
    },
    {
      label: proxy.$t('menu.systemRole'),//'',
      icon: 'setting',
      name: 'authority',
      color: '#8491c3',
      bg: 'rgba(100,149,237,.3)',//矢车菊的蓝色
      url: 'system/role'
    },
    {
      label: proxy.$t('menu.systemMenu'),//'',
      icon: 'menu',
      name: 'menu',
      color: '#4d5aaf',
      bg: 'rgba(176,196,222,.3)',//淡钢蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.sales'),//'',
      icon: 'ShoppingCartFull',
      name: 'about',
      color: '#4d4398',
      bg: 'rgba(135,206,235,.3)',//天蓝色
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.materials'),//'',
      icon: 'aim',
      name: 'about',
      color: '#5654a2',
      bg: 'rgba(0,191,255,.3)',//深天蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.accounting'),//'',,menu.accounting
      icon: 'Money',
      name: 'about',
      color: '#706caa',
      bg: 'rgba(173,216,230,.3)',//淡蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.pp.laborhours'),//'',menu.production
      icon: 'Wallet',
      name: 'about',
      color: '#68699b',
      bg: 'rgba(176,224,230,.3)',//火药蓝
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.quality'),//'', 
      icon: 'Magnet',
      name: 'about',
      color: '#4d5aaf',
      bg: 'rgba(132, 145, 195,.3)',//紅掛空色
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.pp.ec'),//'', menu.ec
      icon: 'Grid',
      name: 'about',
      color: '#867ba9',
      bg: 'rgba(160, 216, 239,.3)',//【空色
      url: 'pp/ec'
    },

    {
      label: proxy.$t('menu.pp.output'),//'',menu.production
      icon: 'TakeawayBox',
      name: 'about',
      color: '#a59aca',
      bg: 'rgba(220, 214, 217,.3)',//薄梅鼠
      url: 'production/pp/output/ppoutputmaster'
    },
    {
      label: proxy.$t('menu.pp.defective'),//'',menu.production
      icon: 'Operation',
      name: 'about',
      color: '#7058a3',
      bg: 'rgba(214, 236, 240,.3)',//月白
      url: 'system/menu'
    },
    {
      label: proxy.$t('menu.about'),//'',menu.production
      icon: 'HelpFilled',
      name: 'about',
      color: '#674598',
      bg: 'rgba(211, 224, 243,.3)',//淡青
      url: 'about'
    },



  ])
  //关闭
  const handleClose = (tag) => {
    toolCards.value.splice(toolCards.value.indexOf(tag), 1)
  }
  const data = {
    newVisitis: {
      expectedData: [100, 120, 161, 134, 105, 160, 165],
      actualData: [120, 82, 91, 154, 162, 140, 145]
    },
    users: {
      expectedData: [200, 192, 120, 144, 160, 130, 140],
      actualData: [180, 160, 151, 106, 145, 150, 130]
    },
    purchases: {
      expectedData: [80, 100, 121, 104, 105, 90, 100],
      actualData: [120, 90, 100, 138, 142, 130, 130]
    },
    shoppings: {
      expectedData: [130, 140, 141, 142, 145, 150, 160],
      actualData: [120, 82, 91, 154, 162, 140, 130]
    },
    wordCloud: [
      {
        name: 'Vue3',
        value: 144
      },
      {
        name: '.net6',
        value: 928
      },
      {
        name: 'Sqlsugar',
        value: 906
      },
      {
        name: 'Redis',
        value: 825
      },
      {
        name: '代码生成',
        value: 514
      },
      {
        name: '开源免费',
        value: 486
      },
      {
        name: '代码简单',
        value: 53
      },
      {
        name: '打赏',
        value: 163
      },
      {
        name: '国际化',
        value: 163
      },
      {
        name: 'Composition api',
        value: 1163
      },
      {
        name: 'Quartz.Net',
        value: 190
      },
      {
        name: 'Element UI',
        value: 190
      }
    ]
  }


  let lineChartData = reactive([])
  const dataType = ref(null)
  function handleSetLineChartData(type) {
    dataType.value = type
    lineChartData = data[type]
  }



</script>

<style lang="scss" scoped>

</style>