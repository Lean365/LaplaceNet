<template>
  <div>
    <div class="card mb10">
      <h4 class="title">{{ $t('layout.ProjectInformation') }}</h4>
    </div>
    <div class="card mb10">
      <h4 class="title"> {{ $t('layout.projectInfo') }}</h4>
      <el-descriptions :column="2" border>
        <el-descriptions-item :label=" $t('layout.currentVersion')" label-align="left">
          <el-tag type="danger">
            {{ version }}
          </el-tag>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('layout.lastBulid')" label-align="left">
          <el-tag type="success">
            {{ lastBuildTime }}
          </el-tag>
        </el-descriptions-item>
        <el-descriptions-item label="Gitee" label-align="left">
          <el-link type="warning" :underline="false" href="https://gitee.com/leansoft365/LaplaceNet" target="_blank">
            Gitee
          </el-link>
        </el-descriptions-item>
        <el-descriptions-item label="Github" label-align="left">
          <el-link type="warning" :underline="false" href="https://github.com/Lean365/LaplaceNet" target="_blank">
            Github </el-link>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('layout.helpguide')" label-align="left">
          <el-link type="primary" :underline="false" href="https://laplacenet.github.io/" target="_blank">
            {{$t('layout.helpguide')}}
          </el-link>
        </el-descriptions-item>
        <el-descriptions-item :label=" $t('btn.preview')" label-align="left">
          <el-link type="primary" :underline="false" href="https://laplacenet.github.io/" target="_blank">
            {{$t('btn.preview')}} </el-link>
        </el-descriptions-item>
      </el-descriptions>
    </div>
    <div class="card mb10">
      <h4 class="title">{{ $t('layout.dependencies') }}</h4>
      <el-descriptions :column="4" border>
        <el-descriptions-item v-for="(value, key) in dependencies" :key="key" width="400px" :label="key">
          <el-tag type="warning">
            {{ value }}
          </el-tag>
        </el-descriptions-item>
      </el-descriptions>
    </div>
    <div class="card">
      <h4 class="title">{{ $t('layout.devDependencies') }}</h4>
      <el-descriptions :column="4" border>
        <el-descriptions-item v-for="(value, key) in devDependencies" :key="key" width="400px" :label="key">
          <el-tag type="danger">
            {{ value }}
          </el-tag>
        </el-descriptions-item>
      </el-descriptions>
    </div>

    <div class="card">
      <h4 class="title">{{ $t('layout.license') }}</h4>
      <a target="_blank" style="color: #5c6b77" href="https://github.com/Lean365/LaplaceNet/blob/master/LICENSE">MIT</a>
    </div>
  </div>
  <div class="chart-warp-top">
    <ChartHead />
  </div>
</template>

<script setup name="about">
  // 引入组件
  const ChartHead = defineAsyncComponent(() => import('./header.vue'));
  const { pkg, lastBuildTime } = __APP_INFO__;
  const { dependencies, devDependencies, version } = pkg;

</script>

<style lang="scss" scoped>
  .card {
    .title {
      margin: 0 0 15px;
      font-size: 17px;
      font-weight: bold;
      color: var(--el-text-color-primary);
    }

    .text {
      font-size: 15px;
      line-height: 25px;
      color: var(--el-text-color-regular);

      .el-link {
        font-size: 15px;
      }
    }
  }
</style>