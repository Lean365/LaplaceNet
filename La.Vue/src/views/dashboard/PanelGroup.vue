<template>
  <el-row :gutter="40" class="panel-group">
    <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('newVisitis')">
        <div class="card-panel-icon-wrapper icon-users">
          <svg-icon name="users" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.onlineUsers') }}</div>
          <div id="onlineNum" class="card-panel-num">{{ state.onlineUserNum }}</div>
        </div>
      </div>
    </el-col>
    <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('stockAmount')">
        <div class="card-panel-icon-wrapper icon-money">
          <svg-icon name="money" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.costTotal') }}</div>
          <div id="costTotal" class="card-panel-num">{{ state.costTotal }}</div>
        </div>

        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.stockAmount') }}</div>
          <div class="card-panel-num" id="stockAmount">{{ state.stockAmount }}</div>
        </div>
      </div>
    </el-col>
    <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('salesAmount')">
        <div class="card-panel-icon-wrapper icon-shipment">
          <svg-icon name="truck" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.Shipment') }}</div>
          <div id="Shipment" class="card-panel-num">{{ state.Shipment }}</div>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.salesAmount') }}</div>
          <div class="card-panel-num" id="salesAmount">{{ state.salesAmount }}</div>
        </div>
      </div>
    </el-col>
    <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
      <div class="card-panel" @click="handleSetLineChartData('production')">
        <div class="card-panel-icon-wrapper icon-cubes">
          <svg-icon name="layer-group" class-name="card-panel-icon" />
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.PoorProduction') }}</div>
          <div id="PoorProduction" class="card-panel-num">{{ state.PoorProduction }}</div>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.production') }}</div>
          <div id="production" class="card-panel-num">{{ state.production }}</div>
        </div>
        <div class="card-panel-description">
          <div class="card-panel-text" v-waves>{{ $t('layout.ecCount') }}</div>
          <div id="ecCount" class="card-panel-num">{{ state.ecCount }}</div>
        </div>
      </div>
    </el-col>


  </el-row>

</template>

<script setup>
import { CountUp } from 'countup.js'
import useSocketStore from '@/store/modules/socket';
const emit = defineEmits()
const { proxy } = getCurrentInstance()

const state = reactive({
  onlineNum: computed(() => {
    return useSocketStore().onlineNum
  }),
  stockAmount: 4563,
  Shipment: 1091,
  ecCount: 30,
  production: 390,
  salesAmount: 650,
  PoorProduction: 13,
  costTotal: 219,
})
onMounted(() => {
  new CountUp('stockAmount', state.stockAmount).start(),
    new CountUp('onlineNum', state.onlineNum).start(),
    new CountUp('Shipment', state.Shipment).start(),
    new CountUp('ecCount', state.ecCount).start(),
    new CountUp('production', state.production).start(),
    new CountUp('salesAmount', state.salesAmount).start(),
    new CountUp('PoorProduction', state.PoorProduction).start(),
    new CountUp('costTotal', state.costTotal).start()
})
function handleSetLineChartData (type) {
  emit('handleSetLineChartData', type)
}
</script>

<style lang="scss" scoped>
.panel-group {
  margin-top: 18px;

  .card-panel-col {
    margin-bottom: 32px;
  }

  .card-panel {
    height: 108px;
    cursor: pointer;
    font-size: 12px;
    position: relative;
    overflow: hidden;
    color: #666;
    background: var(--base-bg-main);
    box-shadow: 4px 4px 40px rgba(0, 0, 0, 0.05);
    border-color: rgba(0, 0, 0, 0.05);

    &:hover {
      .card-panel-icon-wrapper {
        color: #fff;
      }

      .icon-users {
        background: #33cc99;
      }

      .icon-shipment {
        background: #339933;
      }

      .icon-money {
        background: #f4516c;
      }

      .icon-cubes {
        background: #003366;
      }
    }

    .icon-users {
      color: #33cc99;
    }

    .icon-shipment {
      color: #339933;
    }

    .icon-money {
      color: #f4516c;
    }

    .icon-cubes {
      color: #003366;
    }



    .card-panel-icon-wrapper {
      float: left;
      margin: 14px 0 0 14px;
      padding: 16px;
      transition: all 0.38s ease-out;
      border-radius: 6px;
    }

    .card-panel-icon {
      float: left;
      font-size: 48px;
    }

    .card-panel-description {
      float: right;
      font-weight: bold;
      margin: 26px;
      margin-left: 0px;

      .card-panel-text {
        line-height: 18px;
        color: var(--base-color-white);
        font-size: 16px;
        margin-bottom: 12px;
      }

      .card-panel-num {
        font-size: 20px;
        color: var(--base-color-white);
      }
    }
  }
}

@media (max-width: 550px) {
  .card-panel-description {
    display: none;
  }

  .card-panel-icon-wrapper {
    float: none !important;
    width: 100%;
    height: 100%;
    margin: 0 !important;

    .svg-icon {
      display: block;
      margin: 14px auto !important;
      float: none !important;
    }
  }
}
</style>
