<!--
 * @Descripttion: (生产工单/pp_mfg_order)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-03-09)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-03-09)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="生产工厂" prop="moPlant">
        <el-select filterable clearable  v-model="queryParams.moPlant" :placeholder="$t('btn.select')+'生产工厂'">
          <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="订单类型" prop="moOrderType">
        <el-select filterable clearable  v-model="queryParams.moOrderType" :placeholder="$t('btn.select')+'订单类型'">
          <el-option v-for="item in  options.sys_mo_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="生产订单" prop="moOrderNo">
        <el-input clearable v-model="queryParams.moOrderNo" :placeholder="$t('btn.enter')+'生产订单'" />
      </el-form-item>
      <el-form-item label="物料" prop="moOrderItem">
        <el-input clearable v-model="queryParams.moOrderItem" :placeholder="$t('btn.enter')+'物料'" />
      </el-form-item>
      <el-form-item label="批次" prop="moOrderlot">
        <el-input clearable v-model="queryParams.moOrderlot" :placeholder="$t('btn.enter')+'批次'" />
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="10" class="mb8">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['pp:mfgorder:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['pp:mfgorder:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['pp:mfgorder:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button color="#FF69B4" plain icon="download" @click="handleExport" v-hasPermi="['pp:mfgorder:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <!-- 数据区域 -->
    <el-table :data="dataList" v-loading="loading" ref="table" border highlight-current-row @sort-change="sortChange" @selection-change="handleSelectionChange" height="602"
      style="width: 100%">
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="moId" label="ID" align="center" v-if="columns.showColumn('moId')"/>
      <el-table-column prop="moPlant" label="生产工厂" align="center" v-if="columns.showColumn('moPlant')">
        <template #default="scope">
          <dict-tag :options=" options.sys_plant_list " :value="scope.row.moPlant" />
        </template>
      </el-table-column>
      <el-table-column prop="moOrderType" label="订单类型" align="center" v-if="columns.showColumn('moOrderType')">
        <template #default="scope">
          <dict-tag :options=" options.sys_mo_type " :value="scope.row.moOrderType" />
        </template>
      </el-table-column>
      <el-table-column prop="moOrderNo" label="生产订单" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('moOrderNo')"/>
      <el-table-column prop="moOrderItem" label="物料" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('moOrderItem')"/>
      <el-table-column prop="moOrderlot" label="批次" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('moOrderlot')"/>
      <el-table-column prop="moOrderQty" label="工单数量" align="center" v-if="columns.showColumn('moOrderQty')"/>
      <el-table-column prop="moOrderProQty" label="生产数量" align="center" v-if="columns.showColumn('moOrderProQty')"/>
      <el-table-column prop="moOrderDate" label="订单日期" align="center" :show-overflow-tooltip="true" sortable v-if="columns.showColumn('moOrderDate')"/>
      <el-table-column prop="moOrderRoute" label="工艺路线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('moOrderRoute')"/>
      <el-table-column prop="moOrderSerial" label="序列号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('moOrderSerial')"/>
      <el-table-column prop="remark" label="remark" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('remark')"/>
      <el-table-column :label="$t('btn.operate')" align="center" width="160">
        <template #default="scope">
          <el-button v-hasPermi="['pp:mfgorder:edit']" type="success" icon="edit" :title="$t('btn.edit')" @click="handleUpdate(scope.row)"></el-button>
          <el-button v-hasPermi="['pp:mfgorder:delete']" type="danger" icon="delete" :title="$t('btn.delete')" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination class="mt10" background :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />

    <!-- 添加或修改生产工单对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-row :gutter="20">
    
          <el-col :lg="12">
            <el-form-item label="ID" prop="moId">
              <el-input-number clearable v-model.number="form.moId" controls-position="right" :placeholder="$t('btn.enter')+'ID'" :disabled="title==$t('btn.edit')"/>
            </el-form-item>
          </el-col>


          <el-col :lg="12">
            <el-form-item label="生产工厂" prop="moPlant">
              <el-select v-model="form.moPlant" filterable clearable  :placeholder="$t('btn.select')+'生产工厂'">
                <el-option v-for="item in  options.sys_plant_list " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单类型" prop="moOrderType">
              <el-select v-model="form.moOrderType" filterable clearable  :placeholder="$t('btn.select')+'订单类型'">
                <el-option v-for="item in  options.sys_mo_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产订单" prop="moOrderNo">
              <el-input clearable v-model="form.moOrderNo" :placeholder="$t('btn.enter')+'生产订单'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="物料" prop="moOrderItem">
              <el-input clearable v-model="form.moOrderItem" :placeholder="$t('btn.enter')+'物料'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="批次" prop="moOrderlot">
              <el-input clearable v-model="form.moOrderlot" :placeholder="$t('btn.enter')+'批次'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工单数量" prop="moOrderQty">
              <el-input clearable v-model="form.moOrderQty" :placeholder="$t('btn.enter')+'工单数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="生产数量" prop="moOrderProQty">
              <el-input clearable v-model="form.moOrderProQty" :placeholder="$t('btn.enter')+'生产数量'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="订单日期" prop="moOrderDate">
              <el-date-picker clearable v-model="form.moOrderDate" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="工艺路线" prop="moOrderRoute">
              <el-input clearable v-model="form.moOrderRoute" :placeholder="$t('btn.enter')+'工艺路线'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="序列号" prop="moOrderSerial">
              <el-input clearable v-model="form.moOrderSerial" :placeholder="$t('btn.enter')+'序列号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="软删除" prop="isDelete">
              <el-input clearable v-model="form.isDelete" :placeholder="$t('btn.enter')+'软删除'"  :disabled="true"/>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="remark" prop="remark">
              <el-input clearable v-model="form.remark" :placeholder="$t('btn.enter')+'remark'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createBy" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'createBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="createTime" prop="createTime">
              <el-date-picker clearable v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateBy" prop="updateBy">
              <el-input clearable v-model="form.updateBy" :placeholder="$t('btn.enter')+'updateBy'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="updateTime" prop="updateTime">
              <el-date-picker clearable v-model="form.updateTime" type="datetime" :teleported="false" :placeholder="$t('btn.dateselect')"></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button text @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>

  </div>
</template>

<script setup name="ppmfgorder">
// 引入 ppmfgorder操作方法
import { listPpMfgOrder, addPpMfgOrder, delPpMfgOrder, updatePpMfgOrder, getPpMfgOrder, 
 
 } 
from '@/api/production/ppmfgorder.js'
//获取当前组件实例
const { proxy } = getCurrentInstance()
// 选中moId数组数组
const ids = ref([])
// 非单个禁用
const single = ref(true)
// 非多个禁用
const multiple = ref(true)
const loading = ref(false)
  // 显示搜索条件
const showSearch = ref(true)
//使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const queryParams = reactive({
  pageNum: 1,
  pageSize: 17,
  sort: '',
  sortType: 'asc',
  moPlant: undefined,
  moOrderType: undefined,
  moOrderNo: undefined,
  moOrderItem: undefined,
  moOrderlot: undefined,
})
//字段显示控制
const columns = ref([
  { visible: true, prop: 'moId', label: 'ID' },
  { visible: true, prop: 'moPlant', label: '生产工厂' },
  { visible: true, prop: 'moOrderType', label: '订单类型' },
  { visible: true, prop: 'moOrderNo', label: '生产订单' },
  { visible: true, prop: 'moOrderItem', label: '物料' },
  { visible: true, prop: 'moOrderlot', label: '批次' },
  { visible: true, prop: 'moOrderQty', label: '工单数量' },
  { visible: true, prop: 'moOrderProQty', label: '生产数量' },
  { visible: false, prop: 'moOrderDate', label: '订单日期' },
  { visible: false, prop: 'moOrderRoute', label: '工艺路线' },
  { visible: false, prop: 'moOrderSerial', label: '序列号' },
  { visible: false, prop: 'remark', label: '' },
])
  // 总条数
const total = ref(0)
  // 生产工单表格数据
const dataList = ref([])
  // 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])


var dictParams = [
  { dictType: "sys_plant_list" },
  { dictType: "sys_mo_type" },
]
//字典定义
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取生产工单表记录数据
function getList(){
  loading.value = true
  listPpMfgOrder(queryParams).then(res => {
    const { code, data } = res
    if (code == 200) {
      dataList.value = data.result
      total.value = data.totalNum
      loading.value = false
    }
  })
}

// 查询
function handleQuery() {
  queryParams.pageNum = 1
  getList()
}

// 重置查询操作
function resetQuery(){
  proxy.resetForm("queryRef")
  handleQuery()
}

// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.moId);
  single.value = selection.length != 1
  multiple.value = !selection.length;
}

// 自定义排序
function sortChange(column) {
  var sort = undefined
  var sortType = undefined

  if (column.prop != null && column.order != null) {
    sort = column.prop
    sortType = column.order

  }
  queryParams.sort = sort
  queryParams.sortType = sortType
  handleQuery()
}

/*************** form操作 ***************/
//定义响应式变量
const formRef = ref()
  // 弹出层标题
const title = ref("")
// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开变更
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  form: {},
  rules: {
    moPlant: [{ required: true, message: "生产工厂"+proxy.$t('btn.empty'), trigger: "change" }],
    moOrderType: [{ required: true, message: "订单类型"+proxy.$t('btn.empty'), trigger: "change" }],
    moOrderNo: [{ required: true, message: "生产订单"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderItem: [{ required: true, message: "物料"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderlot: [{ required: true, message: "批次"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderQty: [{ required: true, message: "工单数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderProQty: [{ required: true, message: "生产数量"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderDate: [{ required: true, message: "订单日期"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderRoute: [{ required: true, message: "工艺路线"+proxy.$t('btn.empty'), trigger: "blur" }],
    moOrderSerial: [{ required: true, message: "序列号"+proxy.$t('btn.empty'), trigger: "blur" }],
  },
  options: {
    // 生产工厂 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_plant_list: [],
    // 订单类型 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_mo_type: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    moPlant: undefined,
    moOrderType: undefined,
    moOrderNo: undefined,
    moOrderItem: undefined,
    moOrderlot: undefined,
    moOrderQty: undefined,
    moOrderProQty: undefined,
    moOrderDate: undefined,
    moOrderRoute: undefined,
    moOrderSerial: undefined,
    remark: undefined,
    createBy: undefined,
    createTime: undefined,
    updateBy: undefined,
    updateTime: undefined,
  };
  proxy.resetForm("formRef")
}

// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')
  opertype.value = 1
}

// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.moId || ids.value
  getPpMfgOrder(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')
      opertype.value = 2

      form.value = {
      ...data,
      }
    }
  })
}

// 添加&修改 表单提交
function submitForm() {
  proxy.$refs["formRef"].validate((valid) => {
    if (valid) {
      if (form.value.moId != undefined && opertype.value === 2) {
        updatePpMfgOrder(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
        .catch(() => {})
      } else {
        addPpMfgOrder(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
          .catch(() => {})
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.moId || ids.value

  proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
  .then(function () {
      return delPpMfgOrder(Ids)
  })
  .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
  })
  .catch(() => {})
}



// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"生产工单", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/production/PpMfgOrder/export', { ...queryParams })
    })
}

handleQuery()
</script>