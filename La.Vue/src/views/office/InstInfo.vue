<!--
 * @Descripttion: (机构信息/inst_info)
 * @version: (4.0.0)
 * @Author: (Lean365)
 * @Date: (2023-09-07)
-->
<template>
  <div>
    <el-form :model="queryParams" label-position="right" inline ref="queryRef" v-show="showSearch" @submit.prevent>
      <el-form-item label="语言" prop="iiLangkey">
        <el-select filterable clearable  v-model="queryParams.iiLangkey" :placeholder="$t('btn.select')+'语言'">
          <el-option v-for="item in  options.sys_lang_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="编号" prop="iiInstCode">
        <el-input clearable v-model="queryParams.iiInstCode" :placeholder="$t('btn.enter')+'编号'" />
      </el-form-item>
      <el-form-item label="类别" prop="iiCategory">
        <el-select filterable clearable  v-model="queryParams.iiCategory" :placeholder="$t('btn.select')+'类别'">
          <el-option v-for="item in  options.sys_ind_type " :key="item.dictValue" :label="item.dictLabel" :value="item.dictValue">
            <span class="fl">{{ item.dictLabel }}</span>
            <span class="fr" style="color: var(--el-text-color-secondary);">{{ item.dictValue }}</span>          
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="简称" prop="iiShortName">
        <el-input clearable v-model="queryParams.iiShortName" :placeholder="$t('btn.enter')+'简称'" />
      </el-form-item>
      <el-form-item label="全称" prop="iiFullName">
        <el-input clearable v-model="queryParams.iiFullName" :placeholder="$t('btn.enter')+'全称'" />
      </el-form-item>
      <el-form-item label="成立日期">
        <el-date-picker
          v-model="dateRangeIiFoundedTime" 
          type="datetimerange"
          :start-placeholder="$t('btn.dateStart')"
          :end-placeholder="$t('btn.dateEnd')"
          value-format="YYYY-MM-DD HH:mm:ss"
          :default-time="defaultTime"
          :shortcuts="dateOptions">
        </el-date-picker>
      </el-form-item>
      <el-form-item>
        <el-button icon="search" type="primary" @click="handleQuery">{{ $t('btn.search') }}</el-button>
        <el-button icon="refresh" color="#CDD0D6" plain @click="resetQuery">{{ $t('btn.reset') }}</el-button>
      </el-form-item>
    </el-form>
    <!-- 工具区域 -->
    <el-row :gutter="15" class="mb10">
      <el-col :span="1.5">
        <el-button type="primary" v-hasPermi="['inst:info:add']" plain icon="plus" @click="handleAdd">
          {{ $t('btn.add') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="success" :disabled="single" v-hasPermi="['inst:info:edit']" plain icon="edit" @click="handleUpdate">
          {{ $t('btn.edit') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-button type="danger" :disabled="multiple" v-hasPermi="['inst:info:delete']" plain icon="delete" @click="handleDelete">
          {{ $t('btn.delete') }}
        </el-button>
      </el-col>
      <el-col :span="1.5">
        <el-dropdown trigger="click" v-hasPermi="['inst:info:import']">
          <el-button color="#337ecc" plain icon="Upload">
            {{ $t('btn.import') }}<el-icon class="el-icon--right"><arrow-down /></el-icon>
          </el-button>
          <template #dropdown>
            <el-dropdown-menu>
              <el-dropdown-item command="upload">
                <importData
                  templateUrl="office/InstInfo/importTemplate"
                  importUrl="/office/InstInfo/importData"
                  @success="handleFileSuccess"></importData>
              </el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-col>
      <el-col :span="1.5">
        <el-button type="warning" plain icon="download" @click="handleExport" v-hasPermi="['inst:info:export']">
          {{ $t('btn.export') }}
        </el-button>
      </el-col>
      <right-toolbar v-model:showSearch="showSearch" @queryTable="getList" :columns="columns"></right-toolbar>
    </el-row>

    <el-table
      :data="dataList"
      v-loading="loading"
      ref="table"
      border
      header-cell-class-name="el-table-header-cell"
      highlight-current-row
      @sort-change="sortChange"
      @selection-change="handleSelectionChange"
      height="602" style="width: 100%" :summary-method="getSummaries" show-summary>
      <el-table-column type="selection" width="50" align="center"/>
      <el-table-column prop="iiGuid" label="Guid" align="center" v-if="columns.showColumn('iiGuid')"/>
      <el-table-column prop="iiLangkey" label="语言" align="center" v-if="columns.showColumn('iiLangkey')">
        <template #default="scope">
          <dict-tag :options=" options.sys_lang_type " :value="scope.row.iiLangkey"  />
        </template>
      </el-table-column>


      <el-table-column prop="iiInstCode" label="编号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiInstCode')"/>
      <el-table-column prop="iiCategory" label="类别" align="center" v-if="columns.showColumn('iiCategory')">
        <template #default="scope">
          <dict-tag :options=" options.sys_ind_type " :value="scope.row.iiCategory"  />
        </template>
      </el-table-column>


      <el-table-column prop="iiShortName" label="简称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiShortName')"/>
      <el-table-column prop="iiFullName" label="全称" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiFullName')"/>
      <el-table-column prop="iiNature" label="性质" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiNature')"/>
      <el-table-column prop="iiOuterPhone" label="外线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOuterPhone')"/>
      <el-table-column prop="iiInnerPhone" label="内线" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiInnerPhone')"/>
      <el-table-column prop="iiFax" label="传真" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiFax')"/>
      <el-table-column prop="iiPostalcode" label="邮编" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiPostalcode')"/>
      <el-table-column prop="iiEmail" label="邮件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiEmail')"/>
      <el-table-column prop="iiOrgCode" label="组织代码" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOrgCode')"/>
      <el-table-column prop="iiCorporate" label="法人" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCorporate')"/>
      <el-table-column prop="iiRegionId" label="地区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiRegionId')"/>
      <el-table-column prop="iiProvinceId" label="省" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiProvinceId')"/>
      <el-table-column prop="iiCityId" label="市" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCityId')"/>
      <el-table-column prop="iiCountyId" label="县/区" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiCountyId')"/>
      <el-table-column prop="iiTownId" label="镇" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiTownId')"/>
      <el-table-column prop="iiVillageId" label="村" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiVillageId')"/>
      <el-table-column prop="iiAddress" label="地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiAddress')"/>
      <el-table-column prop="iiEnAddress" label="英文地址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiEnAddress')"/>
      <el-table-column prop="iiWebSite" label="网址" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiWebSite')"/>
      <el-table-column prop="iiFoundedTime" label="成立日期" :show-overflow-tooltip="true"  v-if="columns.showColumn('iiFoundedTime')"/>
      <el-table-column prop="iiBusinessScope" label="经营范围" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiBusinessScope')"/>
      <el-table-column prop="iiParentCorp" label="母公司" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiParentCorp')"/>
      <el-table-column prop="iiSortCode" label="排序" align="center" v-if="columns.showColumn('iiSortCode')"/>
      <el-table-column prop="iiisEnabled" label="启用" align="center" v-if="columns.showColumn('iiisEnabled')">
        <template #default="scope">
          <dict-tag :options=" options.sys_flag_list " :value="scope.row.iiisEnabled"  />
        </template>
      </el-table-column>


      <el-table-column prop="iiSlogan" label="企业口号" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiSlogan')"/>
      <el-table-column prop="iiLicenseAnnex" label="营业执照附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiLicenseAnnex')"/>
      <el-table-column prop="iiOtherAnnex" label="其它附件" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('iiOtherAnnex')"/>
      <el-table-column prop="reMarks" label="备注" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('reMarks')"/>
      <el-table-column prop="createBy" label="创建者" align="center" :show-overflow-tooltip="true" v-if="columns.showColumn('createBy')"/>
      <el-table-column prop="createTime" label="创建时间" :show-overflow-tooltip="true"  v-if="columns.showColumn('createTime')"/>
      <el-table-column :label="$t('btn.operation')" width="180">
        <template #default="scope">
          <el-button type="success" size="small" icon="edit" :title="$t('btn.edit')" v-hasPermi="['inst:info:edit']" @click="handleUpdate(scope.row)"></el-button>
          <el-button type="danger" size="small" plain icon="delete" :title="$t('btn.delete')" v-hasPermi="['inst:info:delete']" @click="handleDelete(scope.row)"></el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination :total="total" v-model:page="queryParams.pageNum" v-model:limit="queryParams.pageSize" @pagination="getList" />


    <!-- 添加或修改机构信息对话框 -->
    <el-dialog :title="title" :lock-scroll="false" v-model="open" >
      <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
          <el-tab-pane :label="$t('ptabs.basicInfo')" name="first">
            <el-row :gutter="20">


              <el-col :lg="12">
                <el-form-item label="Guid" prop="iiGuid">
                  <el-input clearable v-model="form.iiGuid" :placeholder="$t('btn.enter')+'Guid'" :disabled="opertype != 1"/>
                </el-form-item>
              </el-col>
          <el-col :lg="12">
            <el-form-item label="语言" prop="iiLangkey">
              <el-select filterable clearable v-model="form.iiLangkey"  :placeholder="$t('btn.select')+'语言'">
                <el-option
                  v-for="item in options.sys_lang_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>


              <el-col :lg="12">
                <el-form-item label="编号" prop="iiInstCode">
                  <el-input clearable v-model="form.iiInstCode" :placeholder="$t('btn.enter')+'编号'" :disabled="opertype != 1"/>
                </el-form-item>
              </el-col>
          <el-col :lg="12">
            <el-form-item label="类别" prop="iiCategory">
              <el-select filterable clearable v-model="form.iiCategory"  :placeholder="$t('btn.select')+'类别'">
                <el-option
                  v-for="item in options.sys_ind_type" 
                  :key="item.dictValue" 
                  :label="item.dictLabel" 
                  :value="item.dictValue"></el-option>
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="简称" prop="iiShortName">
              <el-input clearable v-model="form.iiShortName" :placeholder="$t('btn.enter')+'简称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="全称" prop="iiFullName">
              <el-input clearable v-model="form.iiFullName" :placeholder="$t('btn.enter')+'全称'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="性质" prop="iiNature">
              <el-input clearable v-model="form.iiNature" :placeholder="$t('btn.enter')+'性质'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="外线" prop="iiOuterPhone">
              <el-input clearable v-model="form.iiOuterPhone" :placeholder="$t('btn.enter')+'外线'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="内线" prop="iiInnerPhone">
              <el-input clearable v-model="form.iiInnerPhone" :placeholder="$t('btn.enter')+'内线'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="传真" prop="iiFax">
              <el-input clearable v-model="form.iiFax" :placeholder="$t('btn.enter')+'传真'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮编" prop="iiPostalcode">
              <el-input clearable v-model="form.iiPostalcode" :placeholder="$t('btn.enter')+'邮编'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="邮件" prop="iiEmail">
              <el-input clearable v-model="form.iiEmail" :placeholder="$t('btn.enter')+'邮件'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="组织代码" prop="iiOrgCode">
              <el-input clearable v-model="form.iiOrgCode" :placeholder="$t('btn.enter')+'组织代码'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="法人" prop="iiCorporate">
              <el-input clearable v-model="form.iiCorporate" :placeholder="$t('btn.enter')+'法人'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地区" prop="iiRegionId">
              <el-input clearable v-model="form.iiRegionId" :placeholder="$t('btn.enter')+'地区'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="省" prop="iiProvinceId">
              <el-input clearable v-model="form.iiProvinceId" :placeholder="$t('btn.enter')+'省'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="市" prop="iiCityId">
              <el-input clearable v-model="form.iiCityId" :placeholder="$t('btn.enter')+'市'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="县/区" prop="iiCountyId">
              <el-input clearable v-model="form.iiCountyId" :placeholder="$t('btn.enter')+'县/区'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="镇" prop="iiTownId">
              <el-input clearable v-model="form.iiTownId" :placeholder="$t('btn.enter')+'镇'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="村" prop="iiVillageId">
              <el-input clearable v-model="form.iiVillageId" :placeholder="$t('btn.enter')+'村'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="地址" prop="iiAddress">
              <el-input clearable v-model="form.iiAddress" :placeholder="$t('btn.enter')+'地址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="英文地址" prop="iiEnAddress">
              <el-input clearable v-model="form.iiEnAddress" :placeholder="$t('btn.enter')+'英文地址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="网址" prop="iiWebSite">
              <el-input clearable v-model="form.iiWebSite" :placeholder="$t('btn.enter')+'网址'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
                <el-form-item label="成立日期" prop="iiFoundedTime">
              <el-date-picker v-model="form.iiFoundedTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="经营范围" prop="iiBusinessScope">
              <el-input clearable v-model="form.iiBusinessScope" :placeholder="$t('btn.enter')+'经营范围'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
            <el-form-item label="母公司" prop="iiParentCorp">
              <el-input clearable v-model="form.iiParentCorp" :placeholder="$t('btn.enter')+'母公司'" />
            </el-form-item>
          </el-col>

                      <el-col :lg="12">
                <el-form-item label="排序" prop="iiSortCode">
              <el-input-number clearable v-model.number="form.iiSortCode" :controls="true" controls-position="right" :placeholder="$t('btn.enter')+'排序'" />
                </el-form-item>
          </el-col>
                      <el-col :lg="12">
                <el-form-item label="启用" prop="iiisEnabled">
              <el-radio-group v-model="form.iiisEnabled">
                <el-radio v-for="item in options.sys_flag_list" :key="item.dictValue" :label="parseInt(item.dictValue)">
                  {{item.dictLabel}}
                </el-radio>
              </el-radio-group>
                </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="企业口号" prop="iiSlogan">
              <el-input clearable v-model="form.iiSlogan" :placeholder="$t('btn.enter')+'企业口号'" />
            </el-form-item>
          </el-col>

          <el-col :lg="24">
                <el-form-item label="营业执照附件" prop="iiLicenseAnnex">
              <UploadFile v-model="form.iiLicenseAnnex" :data="{ uploadType: 1 }" />
                </el-form-item>
          </el-col>
          <el-col :lg="24">
                <el-form-item label="其它附件" prop="iiOtherAnnex">
              <UploadFile v-model="form.iiOtherAnnex" :data="{ uploadType: 1 }" />
                </el-form-item>
          </el-col>
          <el-col :lg="24">
                <el-form-item label="备注" prop="reMarks">
              <el-input clearable type="textarea" v-model="form.reMarks" :placeholder="$t('btn.enter')+'备注'"/>
                </el-form-item>
          </el-col>
          <el-col :lg="12">
            <el-form-item label="创建者" prop="createBy">
              <el-input clearable v-model="form.createBy" :placeholder="$t('btn.enter')+'创建者'" />
            </el-form-item>
          </el-col>

          <el-col :lg="12">
                <el-form-item label="创建时间" prop="createTime">
              <el-date-picker v-model="form.createTime" type="datetime" :teleported="false" :placeholder="$t('btn.select')"></el-date-picker>
                </el-form-item>
          </el-col>
        </el-row>
          </el-tab-pane>


          <el-tab-pane :label="$t('ptabs.Onboarding')" name="second">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.qualifications')" name="third">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.annex')" name="fourth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.content')" name="fifth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.trade')" name="sixth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.bank')" name="seventh">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.contact')" name="eighth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.customization')" name="ninth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
          <el-tab-pane :label="$t('ptabs.subInfo')" name="tenth">
        	<el-row :gutter="20">
        	</el-row>
          </el-tab-pane>
        </el-tabs>

      </el-form>
      <template #footer v-if="opertype != 3">
        <el-button color="#CDD0D6" plain @click="cancel">{{ $t('btn.cancel') }}</el-button>
        <el-button type="primary" @click="submitForm">{{ $t('btn.submit') }}</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script setup name="instinfo">
import { listInstInfo,
 addInstInfo, delInstInfo, 
 updateInstInfo,getInstInfo, 
 } 
from '@/api/office/instinfo.js'
import importData from '@/components/ImportData'
//防抖处理函数 import { debounce } from 'lodash';
import { debounce } from 'lodash';
const { proxy } = getCurrentInstance()
//标签页
const activeName = ref('first')

const handleClick = (tab, event) => {
    console.log(tab, event)
  }
// 选中refId数组数组
const ids = ref([])
// 是否加载动画
const loading = ref(false)
// 显示搜索条件
const showSearch = ref(true)
//使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const queryParams = reactive({
  pageNum: 1,
  pageSize: 14,
  sort: '',
  sortType: 'asc',
  iiLangkey: undefined,
  iiInstCode: undefined,
  iiCategory: undefined,
  iiShortName: undefined,
  iiFullName: undefined,
  iiFoundedTime: undefined,
})
//字段显示控制
const columns = ref([
  { visible: false, prop: 'iiGuid', label: 'Guid' },

  { visible: true, prop: 'iiLangkey', label: '语言' },
  { visible: true, prop: 'iiInstCode', label: '编号' },
  { visible: true, prop: 'iiCategory', label: '类别' },
  { visible: true, prop: 'iiShortName', label: '简称' },
  { visible: true, prop: 'iiFullName', label: '全称' },
  { visible: true, prop: 'iiNature', label: '性质' },
  { visible: true, prop: 'iiOuterPhone', label: '外线' },
  { visible: true, prop: 'iiInnerPhone', label: '内线' },
  { visible: false, prop: 'iiFax', label: '传真' },
  { visible: false, prop: 'iiPostalcode', label: '邮编' },
  { visible: false, prop: 'iiEmail', label: '邮件' },
  { visible: false, prop: 'iiOrgCode', label: '组织代码' },
  { visible: false, prop: 'iiCorporate', label: '法人' },
  { visible: false, prop: 'iiRegionId', label: '地区' },
  { visible: false, prop: 'iiProvinceId', label: '省' },
  { visible: false, prop: 'iiCityId', label: '市' },
  { visible: false, prop: 'iiCountyId', label: '县/区' },
  { visible: false, prop: 'iiTownId', label: '镇' },
  { visible: false, prop: 'iiVillageId', label: '村' },
  { visible: false, prop: 'iiAddress', label: '地址' },
  { visible: false, prop: 'iiEnAddress', label: '英文地址' },
  { visible: false, prop: 'iiWebSite', label: '网址' },
  { visible: false, prop: 'iiFoundedTime', label: '成立日期' },
  { visible: false, prop: 'iiBusinessScope', label: '经营范围' },
  { visible: false, prop: 'iiParentCorp', label: '母公司' },
  { visible: false, prop: 'iiSortCode', label: '排序' },
  { visible: false, prop: 'iiisEnabled', label: '启用' },
  { visible: false, prop: 'iiSlogan', label: '企业口号' },
  { visible: false, prop: 'iiLicenseAnnex', label: '营业执照附件' },
  { visible: false, prop: 'iiOtherAnnex', label: '其它附件' },
  { visible: false, prop: 'reMarks', label: '备注' },
  { visible: false, prop: 'createBy', label: '创建者' },
  { visible: false, prop: 'createTime', label: '创建时间' },
])
// 记录数
const total = ref(0)
// 机构信息表格数据
const dataList = ref([])
// 查询参数
const queryRef = ref()
//定义起始时间
const defaultTime = ref([new Date(2000, 1, 1, 0, 0, 0), new Date(2000, 2, 1, 23, 59, 59)])

// 成立日期时间范围
const dateRangeIiFoundedTime = ref([])
//字典参数
var dictParams = [
  { dictType: "sys_lang_type" },
  { dictType: "sys_ind_type" },
  { dictType: "sys_flag_list" },
  { dictType: "sys_is_deleted" },
]
//字典加载
proxy.getDicts(dictParams).then((response) => {
  response.data.forEach((element) => {
    state.options[element.dictType] = element.list
  })
})
//获取机构信息/inst_info表记录数据
function getList(){
  proxy.addDateRange(queryParams, dateRangeIiFoundedTime.value, 'IiFoundedTime');
  loading.value = true
  listInstInfo(queryParams).then(res => {
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
  // 成立日期时间范围
  dateRangeIiFoundedTime.value = []
  proxy.resetForm("queryRef")
  handleQuery()
}
// 多选框选中数据
function handleSelectionChange(selection) {
  ids.value = selection.map((item) => item.iiGuid);
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
const title = ref('')
// 操作类型 1、add 2、edit 3、view
//定义响应式变量
const opertype = ref(0)
//定义对话框打开或关闭
const open = ref(false)
//reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
const state = reactive({
  single: true,
  multiple: true,
  form: {},
  rules: {
    iiGuid: [{ required: true, message: "Guid"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiLangkey: [{ required: true, message: "语言"+ proxy.$t('btn.empty'), trigger: "change" }],
    iiInstCode: [{ required: true, message: "编号"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiCategory: [{ required: true, message: "类别"+ proxy.$t('btn.empty'), trigger: "change" }],
    iiShortName: [{ required: true, message: "简称"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiFullName: [{ required: true, message: "全称"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiNature: [{ required: true, message: "性质"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiOuterPhone: [{ required: true, message: "外线"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiInnerPhone: [{ required: true, message: "内线"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiFax: [{ required: true, message: "传真"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiOrgCode: [{ required: true, message: "组织代码"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiCorporate: [{ required: true, message: "法人"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiRegionId: [{ required: true, message: "地区"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiProvinceId: [{ required: true, message: "省"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiCityId: [{ required: true, message: "市"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiCountyId: [{ required: true, message: "县/区"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiAddress: [{ required: true, message: "地址"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiEnAddress: [{ required: true, message: "英文地址"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiFoundedTime: [{ required: true, message: "成立日期"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiBusinessScope: [{ required: true, message: "经营范围"+ proxy.$t('btn.empty'), trigger: "blur" }],
    iiSortCode: [{ required: true, message: "排序"+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    iiisEnabled: [{ required: true, message: "启用"+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
    uDF51: [{ required: true, message: "自定义1"+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF52: [{ required: true, message: "自定义2"+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF53: [{ required: true, message: "自定义3"+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF54: [{ required: true, message: "自定义4"+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF55: [{ required: true, message: "自定义5"+ proxy.$t('btn.empty'), trigger: "blur" }],
    uDF56: [{ required: true, message: "自定义6"+ proxy.$t('btn.empty'), trigger: "blur" }],
    isDeleted: [{ required: true, message: "软删除"+ proxy.$t('btn.empty'), trigger: "blur", type: "number" }],
  },
  options: {
    // 语言 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_lang_type: [],
    // 类别 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_ind_type: [],
    // 启用 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_flag_list: [],
    // 软删除 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
    sys_is_deleted: [],
  }
})
//将响应式对象转换成普通对象
const { form, rules, options, single, multiple } = toRefs(state)

// 关闭dialog
function cancel(){
  open.value = false
  reset()
}

// 重置表单
function reset() {
  form.value = {
    iiGuid: null,
    iiLangkey: null,
    iiInstCode: null,
    iiCategory: null,
    iiShortName: null,
    iiFullName: null,
    iiNature: null,
    iiOuterPhone: null,
    iiInnerPhone: null,
    iiFax: null,
    iiPostalcode: null,
    iiEmail: null,
    iiOrgCode: null,
    iiCorporate: null,
    iiRegionId: null,
    iiProvinceId: null,
    iiCityId: null,
    iiCountyId: null,
    iiTownId: null,
    iiVillageId: null,
    iiAddress: null,
    iiEnAddress: null,
    iiWebSite: null,
    iiFoundedTime: null,
    iiBusinessScope: null,
    iiParentCorp: null,
    iiSortCode: null,
    iiisEnabled: null,
    iiSlogan: null,
    iiLicenseAnnex: null,
    iiOtherAnnex: null,
    uDF01: null,
    uDF02: null,
    uDF03: null,
    uDF04: null,
    uDF05: null,
    uDF06: null,
    uDF51: null,
    uDF52: null,
    uDF53: null,
    uDF54: null,
    uDF55: null,
    uDF56: null,
    reMarks: null,
    isDeleted: null,
    createBy: null,
    createTime: null,
    updateBy: null,
    updateTime: null,
  };
  proxy.resetForm("formRef")
}
// 添加按钮操作
function handleAdd() {
  reset();
  open.value = true
  title.value = proxy.$t('btn.add')+'机构信息'
  opertype.value = 1
  form.value.iiGuid= crypto.randomUUID()
  form.value.iiLangkey= []
  form.value.iiCategory= []
  form.value.iiFoundedTime= new Date()
  form.value.iiSortCode= 0
  form.value.iiisEnabled= 0
}
// 修改按钮操作
function handleUpdate(row) {
  reset()
  const id = row.iiGuid || ids.value
  getInstInfo(id).then((res) => {
    const { code, data } = res
    if (code == 200) {
      open.value = true
      title.value = proxy.$t('btn.edit')+'机构信息'
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

      if (form.value.iiGuid != undefined && opertype.value === 2) {
        updateInstInfo(form.value).then((res) => {
          proxy.$modal.msgSuccess(proxy.$t('common.Modicompleted'))
          open.value = false
          getList()
        })
      } else {
        addInstInfo(form.value).then((res) => {
            proxy.$modal.msgSuccess(proxy.$t('common.Newcompleted'))
            open.value = false
            getList()
          })
      }
    }
  })
}

// 删除按钮操作
function handleDelete(row) {
  const Ids = row.iiGuid || ids.value

 proxy.$confirm(proxy.$t('common.confirmDel') + Ids +proxy.$t('common.confirmDelDataitems'))
    .then(function () {
      return delInstInfo(Ids)
    })
    .then(() => {
      getList()
      proxy.$modal.msgSuccess(proxy.$t('common.Delcompleted'))
    })
}



// 导入数据成功处理
const handleFileSuccess = (response) => {
  const { item1, item2 } = response.data
  var error = ''
  item2.forEach((item) => {
    error += item.storageMessage + ','
  })
  proxy.$alert(item1 + '<p>' + error + '</p>', proxy.$t('btn.importResults'), {
    dangerouslyUseHTMLString: true
  })
  getList()
}

// 导出按钮操作
function handleExport() {
  proxy
    .$confirm(proxy.$t('common.confirmExport')+"机构信息", proxy.$t('common.warningTips'), {
      confirmButtonText: proxy.$t('btn.submit'),
      cancelButtonText: proxy.$t('btn.cancel'),
      type: "warning",
    })
    .then(async () => {
      await proxy.downFile('/office/InstInfo/export', { ...queryParams })
    })
}


  //自定义统计函数
  const getSummaries = (param) => {
    const { columns, data } = param;
    const sums = [];
    columns.forEach((column, index) => {
      if (index === 1) {
        sums[index] = '合计'
        return
      }
      //合计的索引
      // if (index === 2 || index === 3 || index === 4 || index === 5 || index === 6) {
      if (index === 6 || index === 7) {
        const values = data.map(item => Number(item[column.property]));
        if (!values.every(value => isNaN(value))) {
          sums[index] = values.reduce((prev, curr) => {
            const value = Number(curr)
            if (!isNaN(value)) {
              return (prev + curr)
            } else {
              return prev
            }
          }, 0)
          // sums[index] = (sums[index]).toFixed(2); 
          sums[index] = ThousandWithNumber(sums[index])// !!重点 要对结果进行转换
        }
      }

    })
    //加减运算
    sums[8] = '未完成台数：' + ThousandWithNumber(formatNumber(sums[6]) - formatNumber(sums[7])).toString()

    return sums
  }
  //千分位转number
  const formatNumber = (val) => {
    if (val == null || val == 0) {
      return val = '0.00'
    } else {
      return val.replace(/,/g, '');
    }
  }
  // 千分位函数
  function ThousandWithNumber(value) {
    if (!value) return 0
    // 获取整数部分
    const wholePart = Math.trunc(value)
    // 梳理数据 -> 千分位
    const wholePartFormat = wholePart.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,')
    // 处理小数部分
    let decimalPart = ''
    // 将数值截取为小数部分和整数部分
    const valueArray = value.toString().split('.')
    if (valueArray.length === 2) { // 有小数部分
      decimalPart = valueArray[1].toString() // 取得小数部分
      return wholePartFormat + '.' + decimalPart
    }
    return wholePartFormat + decimalPart
  }

handleQuery()
</script>