<template>
  <div class="uploadData">
    <el-upload ref="uploadRef" :limit="1" name="file" accept=".xlsx" :before-upload="handleBeforeUpload"
      :data="uploadData" :headers="headers" :action="uploadFileUrl" v-loading="isUploading"
      :on-progress="handleFileUploadProgress" :on-success="handleFileSuccess" :auto-upload="true">
      <el-button type="primary" icon="Upload">{{$t('fupload.uploadFile')}}</el-button>

      <template #tip>
        <div class="el-upload__tip text-center">
          <span>{{$t('fupload.uploadFileTypeMsga')}}<b style="color: #f56c6c">{{ $t('fupload.uploadFileType')
              }}</b>{{$t('fupload.uploadFileTypeMsgb')}}</span>
          <span>{{$t('fupload.uploadFileSizeMsga')}}<b style="color: #f56c6c">{{ $t('fupload.uploadFileSize')
              }}</b>{{$t('fupload.uploadFileSizeMsgb')}}</span>
          <el-link type="primary" @click="importTemplate" icon="Bottom"> {{$t('fupload.downloadTemplate')}} </el-link>
        </div>
      </template>
    </el-upload>
  </div>
</template>
<script setup>
  import { getToken } from '@/utils/auth'

  const { proxy } = getCurrentInstance()
  const emit = defineEmits()

  const props = defineProps({
    importUrl: {
      type: String
    },
    templateUrl: {
      type: String
    },
    // 大小限制(MB)
    fileSize: {
      type: Number,
      default: 100
    },
    // 上传携带的参数
    data: {
      type: Object
    }
  })

  const baseUrl = import.meta.env.VITE_APP_BASE_API
  const uploadFileUrl = ref(baseUrl + props.importUrl) // 上传数据url
  const headers = ref({ Authorization: 'Bearer ' + getToken() })
  const uploadData = computed(() => props.data)
  const isUploading = ref(false)

  const maxSize = 100 * 1024 * 1024 // 限制文件大小为 100MB
  /**文件上传前判断 文件大小 */
  const handleBeforeUpload = (file) => {
    if (file.size > maxSize) {
      proxy.$modal.msgError(proxy.$t('fupload.uploadFileSizeMsga') + maxSize / 1024 / 1024 + 'MB')
      return false
    }
    return true
  }
  /**文件上传中处理 */
  const handleFileUploadProgress = (event, file, fileList) => {
    isUploading.value = true
  }
  /** 文件上传成功处理 */
  const handleFileSuccess = (response, file, fileList) => {
    const { code, msg } = response

    isUploading.value = false
    proxy.$refs['uploadRef'].clearFiles()
    proxy.$refs['uploadRef'].handleRemove(file)

    if (code != 200) {
      proxy.$modal.msgError(proxy.$t('fupload.uploadFileError') + msg)
    } else {
      emit('success', response)
    }
  }

  function importTemplate() {
    proxy.downFile(props.templateUrl)
  }
</script>
<style lang="scss" scoped>
  .uploadData {
    padding: 10px;
  }
</style>