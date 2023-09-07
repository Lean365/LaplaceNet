<template>
  <div ref="chartRef" :class="className" :style="{ height: height, width: width }" />

</template>

<script setup>
  import * as echarts from 'echarts'
  import { listUseAll } from '@/api/system/user'
  import useSocketStore from '@/store/modules/socket'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  const state = reactive({
    applyChart: {},
    dataList: undefined,
    AppName: undefined,
    getData: undefined,
    echartsData: [],
    online: useSocketStore().onlineNum,
  })
  let chart = null
  const props = defineProps({
    className: {
      type: String,
      default: 'chart',
    },
    width: {
      type: String,
      default: '100%',
    },
    height: {
      type: String,
      default: '550px',
    },
  })
  function initChart() {
    chart = echarts.init(proxy.$refs.chartRef)

    chart.setOption({
      // 图例
      legend: {

        left: 'center',
        top: 'bottom',
        bottom: '10',
      },
      //提示条设置
      tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b} : {c} ({d}%)'
      },
      // 设置饼图标题，位置设为顶部居中
      title: {
        text: '用户统计(User statistics)',
        subtext: '在线占比(Online percentage)',
        left: 'center'
      },
      // 设置工具箱，表格优化
      toolbox: {
        show: true,
        feature: {
          mark: { show: true },
          //数据视图
          dataView: {
            show: true,
            //只读设置
            readOnly: true,
            //lang: ['数据视图', '关闭', '刷新'],
            //小图标的文本提示，配合showTitle使用
            title: "数据视图",
            //html格式转化
            optionToContent: function (opt) {
              var series = opt.series;
              var table = '<table border="1" style="width:50%;user-select:text;text-align:center;border-collapse:collapse;"><thead style="font-weight:bold;">'
                + '<tr>';
              for (var i = 0, l = series.length; i < l; i++) {
                table += '<td>' + series[i].name + '-Type</td><td>Qty</td>';
              }
              table += '</tr></thead><tbody>';
              for (var i = 0, l = series.length; i < l; i++) {
                console.log(series[i].data);
                for (var j = 0; j < series[i].data.length; j++) {
                  table += '<tr><td>' + series[i].data[j].name + '</td>'
                    + '<td>' + series[i].data[j].value + '</td></tr>';
                }
                table += '</tr>';
              }
              table += '</tbody></table>';
              return table;
            },

          },
          restore: { show: true },
          saveAsImage: { show: true, }
        }
      },
      series: [
        {
          name: 'User',
          type: 'pie',
          radius: [20, 140],
          center: ['50%', '50%'],
          roseType: 'radius',
          label: {
            show: true,
            formatter: "{b} : {c} ({d}%)" // b代表名称，c代表对应值，d代表百分比
          },
          //radius: "50%", //饼图半径
          data: [],
          //每一个扇形的颜色
          itemStyle: {
            borderRadius: 5,
            normal: {
              color: function (colors) {
                let colorList = [
                  '#fc8251',
                  '#5470c6',
                  '#33FFDD',
                ];
                return colorList[colors.dataIndex];
              }
            },
          }
        },

      ],
      emphasis: {
        itemStyle: {
          shadowBlur: 10,
          shadowOffsetX: 0,
          shadowColor: 'rgba(0, 0, 0, 0.5)'
        }
      }
    });
  }

  // 异步 操作获取用户信息
  function getUserList() {
    //在Promise上有两个函数 resolve (成功之后的回调函数)和 reject (失败后的回调函数)；
    return new Promise((resolve, reject) => {
      // 异步 操作
      listUseAll()
        .then((res) => {
          state.dataList = res.data.result
          resolve(res)
          state.AppName = state.dataList.map(item => {
            return "TotalUsers"//返回行数
          })
          //state.online = useSocketStore().onlineNum
          // 如果分离出来的字段存在重复的，需要计算重复字段出现的次数 ['A','B','C','A']
          state.getData = state.AppName.reduce((obj, name) => {
            if (name in obj) {
              obj[name]++
            } else {
              obj[name] = 1
            }
            return obj //{'A':2,'B':1,'C':1}
          }, {})
          //存放形式为[{name1:value},{name2:value2}]  
          //let dataList = [];
          //计算完数组中每个元素出现的次数,得到一个对象 属性->name 属性值->value
          for (const key in state.getData) {
            let obj1 = { name: key, value: state.getData[key] }
            state.echartsData.push(obj1)
            let obj2 = { name: "Online", value: state.online }
            state.echartsData.push(obj2)


          }

          state.applyChart = state.echartsData
          chart.setOption({
            series: [{
              // 饼图的数据源
              data: state.echartsData,
            }]
          });
          //resolve(res)
        })
        .catch((error) => {
          console.error(error)
          reject('获取用户信息失败')
        })
    })
  }
  //state.echartsData = state.dataList
  getUserList()
  onMounted(() => {
    initChart()
  })

</script>