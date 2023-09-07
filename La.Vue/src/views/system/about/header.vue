<template>
  <div class="big-data-up mb315">
    <div class="up-right">
      <i class="el-icon-time mr5"></i>
      <!-- <span>{{ state.time.txt }}</span> -->
      <span>{{ $t('layout.nowMoment') }}:</span>
      <font color="red"><span> {{ nowTime }} </span></font>
      <span> [{{ $t('layout.CST') }} ({{ timezone }}): </span>
      <span> {{ nowDate }} ]</span>
      <span> ({{ nowYear }},{{ $t('layout.quarterth') }}{{ nowQuarter }}{{ $t('layout.quarteris') }}{{
        $t('layout.weekth')}}{{ nowWeek }}{{
        $t('layout.weekis')}}{{
        $t('layout.Dayth')}}{{ nowDay }}{{
        $t('layout.Dayis')}})</span>
    </div>

  </div>
  <div class="big-data-up mb315">
    <div class="up-left">
      <i class="el-icon-time mr5"></i>
      <!-- <span>{{ state.time.txt }}</span> -->
      <!-- <span>{{ $t('layout.CST') }} ({{ timezone }}): </span>
      <span> {{ nowDate }} </span> -->
      <!-- <span>{{ nowYear }},{{ $t('layout.quarterth') }}{{ nowQuarter }}{{ $t('layout.quarteris') }}{{
      $t('layout.weekth')}}{{ nowWeek }}{{
      $t('layout.weekis')}}{{
      $t('layout.Dayth')}}{{ nowDay }}{{
      $t('layout.Dayis')}}</span> -->
    </div>

  </div>
  <div class="big-data-up mb315">
    <div class="up-center">
      <span>{{$t('layout.hostName')}}</span>
    </div>
  </div>
  <div class="">
    <!--动态将图片轮播图的容器高度设置成与图片一致-->
    <div class="block text-center">
      <el-carousel :interval="4000" style="height: 256px;">
        <el-carousel-item v-for="item in carouselItems" :key="item.id">
          <img :src="item.imageUrl" alt="Carousel Image" style="height: 128px;">
        </el-carousel-item>
      </el-carousel>
    </div>


  </div>
</template>

<script setup name="chartHead">
  //import { formatNowDateTime } from '@/utils/date'
  import moment from 'moment'
  import zonetime from 'moment-timezone'
  import "moment/dist/locale/zh-cn"
  import 'moment/dist/locale/zh-tw'
  import 'moment/dist/locale/ja'
  import useAppStore from '@/store/modules/app'

  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  const lang = computed(() => {
    return useAppStore().lang
  })

  const timezone = moment.tz.guess()
  const langselect = lang
  const nowTime = ref('')
  const nowDate = ref('')
  const nowYear = ref('')
  const nowQuarter = ref('')
  const nowWeek = ref('')
  const nowDay = ref('')

  // 定义变量内容
  const state = reactive({
    time: {
      txt: '',
      fun: 0,
    },
  });
  const carouselItems = ref([
    {
      id: 1,
      imageUrl: 'src/assets/logo/Antares.png'
    },
    {
      id: 2,
      imageUrl: 'src/assets/logo/Laplace.png'
    },
    {
      id: 3,
      imageUrl: 'src/assets/logo/Lean365.png'
    }
  ]);
  // // 初始化时间
  // const initTime = () => {
  //   state.time.txt = formatNowDateTime(new Date(), 'YYYY-mm-dd HH:MM:SS WWW ZZZ QQQQ');
  //   state.time.fun = window.setInterval(() => {
  //     state.time.txt = formatNowDateTime(new Date(), 'YYYY-mm-dd HH:MM:SS WWW ZZZ QQQQ');
  //   }, 1000);
  // };

  // // 页面加载前
  // onBeforeMount(() => {
  //   initTime();
  // });
  // // 页面卸载时
  // onUnmounted(() => {
  //   window.clearInterval(state.time.fun);
  // });

  onMounted(() => {
    updateCurrentTime();
    setInterval(updateCurrentTime, 1000);
  });

  function updateCurrentTime() {
    if (langselect.value === ("en")) {
      moment.locale('en'); // default the locale to English
      var localLocale = moment();
      localLocale.locale("en"); // set this instance to use French
      nowTime.value = localLocale.format('LTS') // set this instance to use French
      nowDate.value = localLocale.format('llll') // set this instance to use French

    } else if (langselect.value === ("zh-tw")) {
      moment.locale('en'); // default the locale to English
      var localLocale = moment();
      localLocale.locale("zh-tw"); // set this instance to use French
      nowTime.value = localLocale.format('LTS') // set this instance to use French
      nowDate.value = localLocale.format('LLLL') // set this instance to use French
      //nowDate.value = proxy.$t('common.Todayis') + moment().years() + proxy.$t('common.Yearis') + moment().quarters() + proxy.$t('common.quarterth') + moment().weeksInYear() + proxy.$t('common.weekth') + moment().dayOfYear() + proxy.$t('common.Dayth')
    } else if (langselect.value === ("zh-cn")) {
      moment.locale('en'); // default the locale to English
      var localLocale = moment();
      localLocale.locale("zh-cn"); // set this instance to use French
      nowTime.value = localLocale.format('LTS') // set this instance to use French
      nowDate.value = localLocale.format('llll') // set this instance to use French
      //nowDate.value = proxy.$t('common.Todayis') + moment().years() + proxy.$t('common.Yearis') + moment().quarters() + proxy.$t('common.quarterth') + moment().weeksInYear() + proxy.$t('common.weekth') + moment().dayOfYear() + proxy.$t('common.Dayth')
    } else if (langselect.value === ("ja")) {
      moment.locale('en'); // default the locale to English
      var localLocale = moment();
      localLocale.locale("ja"); // set this instance to use French
      nowTime.value = localLocale.format('LTS') // set this instance to use French
      nowDate.value = localLocale.format('llll') // set this instance to use French
      //nowDate.value = proxy.$t('common.Todayis') + moment().years() + proxy.$t('common.Yearis') + moment().quarters() + proxy.$t('common.quarterth') + moment().weeksInYear() + proxy.$t('common.weekth') + moment().dayOfYear() + proxy.$t('common.Dayth')
    } else {
      moment.locale('en'); // default the locale to English
      var localLocale = moment();
      localLocale.locale("en"); // set this instance to use French
      nowTime.value = localLocale.format('LTS') // set this instance to use French
      nowDate.value = localLocale.format('llll') // set this instance to use French
      //nowDate.value = proxy.$t('common.Todayis') + moment().years() + proxy.$t('common.Yearis') + moment().quarters() + proxy.$t('common.quarterth') + moment().weeksInYear() + proxy.$t('common.weekth') + moment().dayOfYear() + proxy.$t('common.Dayth')
    }
  }

  nowYear.value = moment().years().toString().trim() //+ proxy.$t('common.Yearis') + moment().quarters() + proxy.$t('common.quarterth') + moment().weeksInYear() + proxy.$t('common.weekth') + moment().dayOfYear() + proxy.$t('common.Dayth')
  nowQuarter.value = moment().quarters().toString().trim()
  nowWeek.value = moment().weeks().toString().trim()
  nowDay.value = moment().dayOfYear().toString().trim()
</script>

<style scoped lang="scss">
  .big-data-up {
    height: 55px;
    width: 100%;
    display: flex;
    align-items: center;
    padding: 0 15px;
    color: var(--el-color-primary);
    overflow: hidden;
    position: relative;

    .up-left {
      position: absolute;
    }

    .up-center {
      width: 100%;
      display: flex;
      justify-content: center;
      font-size: 18px;
      letter-spacing: 5px;
      background-image: -webkit-linear-gradient(left,
          var(--el-color-primary),
          var(--el-color-primary-light-3) 25%,
          var(--el-color-primary) 50%,
          var(--el-color-primary-light-3) 75%,
          var(--el-color-primary));
      -webkit-text-fill-color: transparent;
      -webkit-background-clip: text;
      background-clip: text;
      background-size: 200% 100%;
      -webkit-animation: masked-animation-data-v-b02d8052 4s linear infinite;
      animation: masked-animation-data-v-b02d8052 4s linear infinite;
      -webkit-box-reflect: below -2px -webkit-gradient(linear, left top, left bottom, from(transparent), to(hsla(0, 0%, 100%, 0.1)));
      position: relative;

      @keyframes masked-animation {
        0% {
          background-position: 0 0;
        }

        100% {
          background-position: -100% 0;
        }
      }

      position: relative;

      &::after {
        content: '';
        width: 250px;
        position: absolute;
        bottom: -15px;
        left: 50%;
        transform: translateX(-50%);
        border: 1px transparent solid;
        border-image: linear-gradient(to right, var(--el-color-primary-light-9), var(--el-color-primary)) 1 10;
      }

      span {
        cursor: pointer;
      }
    }
  }
</style>