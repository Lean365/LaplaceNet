<template>
  <div class="base" :style="{border: canvasState? '1px dashed #eee': '0px dashed #eee'}">
    <div v-if="childs.length != 0" v-for="child in childs" >
      <div v-if="child.type == 'com-sougn-base-layout-center'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-layout-center v-bind:configs="child" :parentId="child.id"></com-sougn-base-layout-center>
      </div>
      <div v-if="child.type == 'com-sougn-base-layout-row'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-layout-row v-bind:configs="child" :parentId="child.id"></com-sougn-base-layout-row>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-font'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-font v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-font>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-input-text'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-input-text v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-input-text>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-radio'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-radio v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-radio>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-checkbox'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-checkbox v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-checkbox>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-select'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-select v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-select>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-switch'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-switch v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-switch>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-slider'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-slider v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-slider>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-time-select'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-time-select v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-time-select>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-time-picker'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-time-picker v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-time-picker>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-date-picker'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-date-picker v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-date-picker>
      </div>
      <div v-if="child.type == 'com-sougn-base-assembly-date-time-picker'">
        <config :configs="child.configs" :id="child.id" v-if="canvasState"></config>
        <com-sougn-base-assembly-date-time-picker v-bind:configs="child" :parentId="child.id"></com-sougn-base-assembly-date-time-picker>
      </div>
    </div>
    <div v-if="canvasState">
      <div class="add"><span @click="addSlort = !addSlort">????????????</span></div>
      <div class="close-quick" v-if="addSlort" @click="addSlort = !addSlort">
        <div class="swiper" >
          <div  class="swiper-all" @click.stop="end">
            <el-tabs v-model="activeName">
              <el-tab-pane label="????????????" name="first">
                <el-row style="padding:10px 0px;border-bottom:1px solid #eee;">
                  <el-col :span="6">
                    <img src="" style="width:100px;height:100px;background-color:#eee;border-radius:3px;"/>
                  </el-col>
                  <el-col :span="13">
                    <p>????????????</p>
                  </el-col>
                  <el-col :span="5">
                    <div>
                      <el-button type="primary" plain size="mini" @click="assemblyAdd('com-sougn-base-layout-center',true)">??????</el-button>
                    </div>
                  </el-col>
                </el-row>
                <el-row style="padding:10px 0px;border-bottom:1px solid #eee;">
                  <el-col :span="6">
                    <img src="" style="width:100px;height:100px;background-color:#eee;border-radius:3px;"/>
                  </el-col>
                  <el-col :span="13">
                    <p>????????????</p>
                  </el-col>
                  <el-col :span="5">
                    <div style="margin:10px;">
                      <el-button type="info" plain size="mini" @click="assemblyConfigRow = !assemblyConfigRow">??????</el-button>
                    </div>
                  </el-col>
                </el-row>
              </el-tab-pane>
              <el-tab-pane label="????????????" name="second">
                <el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-font',true)">????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-input-text',true)">???????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-radio',true)">???????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-checkbox',true)">???????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-select',true)">???????????????</div></el-row>
                  <!--<el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-switch',true)">????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-slider',true)">????????????</div></el-row>-->
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-time-select',true)">??????????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-time-picker',true)">??????????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-date-picker',true)">??????????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-date-time-picker',true)">?????????????????????</div></el-row>
                  <el-row :span="3"><div @click="assemblyAdd('com-sougn-base-assembly-line',true)">???????????????</div></el-row>
                  <!--<el-row :span="3">??????????????????</el-row>
                  <el-row :span="3">???????????????</el-row>-->
                </el-row>
              </el-tab-pane>
            </el-tabs>
          </div>
        </div>
      </div>
      <div class="close-quick" v-if="assemblyConfigRow" @click="assemblyConfigRow = !assemblyConfigRow">
        <div class="swiper" @click.stop="end">
          <i class="el-icon-close" @click="assemblyConfigRow = !assemblyConfigRow" style="top: 8px;right:8px;position: relative;float: right;"></i>
          <el-form label-width="80px" size="mini" style="margin-top: 30px;padding: 0px 50px;">
            <el-form-item label="????????????">
              <el-input v-model="rows"></el-input>
            </el-form-item>
          </el-form>
          <el-row>
            <el-col v-bind:span="row" v-for="row in rowsEl" style="background-color:rgb(255, 255, 224);border: 1px solid red;">{{row}}</el-col>
          </el-row>
          <div style="margin:10px;">
            <el-button type="primary" plain size="mini" @click="assemblyAddRow('com-sougn-base-layout-row',true)">??????</el-button>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  import ComSougnBaseLayoutCenter from './ComSougnBaseLayoutCenter'
  import ComSougnBaseLayoutRow from './ComSougnBaseLayoutRow'
  import ComSougnBaseAssemblyInputText from './ComSougnBaseAssemblyInputText'
  import ComSougnBaseAssemblyFont from './ComSougnBaseAssemblyFont'
  import ComSougnBaseAssemblyRadio from './ComSougnBaseAssemblyRadio'
  import ComSougnBaseAssemblyCheckbox from './ComSougnBaseAssemblyCheckbox'
  import ComSougnBaseAssemblySelect from './ComSougnBaseAssemblySelect'
  import ComSougnBaseAssemblySwitch from './ComSougnBaseAssemblySwitch'
  import ComSougnBaseAssemblySlider from './ComSougnBaseAssemblySlider'
  import ComSougnBaseAssemblyTimeSelect from './ComSougnBaseAssemblyTimeSelect'
  import ComSougnBaseAssemblyTimePicker from './ComSougnBaseAssemblyTimePicker'
  import ComSougnBaseAssemblyDatePicker from './ComSougnBaseAssemblyDatePicker'
  import ComSougnBaseAssemblyDateTimePicker from './ComSougnBaseAssemblyDateTimePicker'
  import Config from './Config'

export default {
  name: 'ComSougnBaseBi',
  props: ['childs','parentId'],
  data () {
    return {
      addSlort: false,
      activeName: 'first',
      assemblyConfigRow: false,
      rows: '12,2,10'
    }
  },
  components: {
    ComSougnBaseLayoutCenter: ComSougnBaseLayoutCenter,
    ComSougnBaseAssemblyFont: ComSougnBaseAssemblyFont,
    ComSougnBaseLayoutRow: ComSougnBaseLayoutRow,
    Config:Config,
    ComSougnBaseAssemblyInputText:ComSougnBaseAssemblyInputText,
    ComSougnBaseAssemblyRadio: ComSougnBaseAssemblyRadio,
    ComSougnBaseAssemblyCheckbox: ComSougnBaseAssemblyCheckbox,
    ComSougnBaseAssemblySelect: ComSougnBaseAssemblySelect,
    ComSougnBaseAssemblySwitch: ComSougnBaseAssemblySwitch,
    ComSougnBaseAssemblySlider:ComSougnBaseAssemblySlider,
    ComSougnBaseAssemblyTimeSelect:ComSougnBaseAssemblyTimeSelect,
    ComSougnBaseAssemblyTimePicker:ComSougnBaseAssemblyTimePicker,
    ComSougnBaseAssemblyDatePicker:ComSougnBaseAssemblyDatePicker,
    ComSougnBaseAssemblyDateTimePicker:ComSougnBaseAssemblyDateTimePicker,
  },
  computed: {
    rowsEl:function (){
      return this.rows.split(',')
    },
    canvasState:function (){//?????????????????????debug?????????true??????????????????
      let stateCanvas = this.$store.state.canvas.canvas
      for(let i in stateCanvas.config){
        if(stateCanvas.config[i].id === 'canvasState'){
          return stateCanvas.config[i].value
        }
      }
    }
  },
  mounted () {

  },
  methods: {
    assemblyAdd: function (type , haveSlot) {
      let assembly = {
        id: new Date().getTime(),
        type: type,
        haveSlot: haveSlot,
        configs: getDefConfig(type,this.$store.state.type.type),
        childs:[],
        parentId: this.parentId
      }
      this.$store.commit('ASSEMBLY_ADD', assembly)
      this.addSlort = false
    },
    assemblyAddRow: function (type, haveSlot) {
      let assembly = {
        id: new Date().getTime(),
        type: type,
        haveSlot: haveSlot,
        configs: getDefConfig(type,this.$store.state.type.type),
        childs:[],
        parentId: this.parentId
      }
      for(let i in this.rowsEl){
        sleep(1)
        assembly.childs.push({
          id: new Date().getTime(),
          type: type,
          haveSlot: haveSlot,
          configs: this.rowsEl[i],
          childs:[],
          parentId: assembly.id
        })
      }
      this.$store.commit('ASSEMBLY_ADD', assembly)
      this.assemblyConfigRow = false
    },
    end:function (){

    }
  }
}

function getDefConfig(type,config){
    let configs = []
    for(let i in config){
      if(config[i].type == type ){
        configs = cloneObj(config[i].config);
      }else if(config[i].type == type ){
        configs = cloneObj(config[i].config);
      }
    }
    return configs
}

var cloneObj = function (obj) {
  var newObj = {};
  if (obj instanceof Array) {
    newObj = [];
  }
  for (var key in obj) {
    var val = obj[key];
    //newObj[key] = typeof val === 'object' ? arguments.callee(val) : val; //arguments.callee ??????????????????????????????????????????????????????, ??????????????????????????????
    newObj[key] = typeof val === 'object' ? cloneObj(val): val;
  }
  return newObj;
};

function sleep(d){
  for(var t = Date.now();Date.now() - t <= d;);
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.base{

  border-radius: 5px;
  position: relative;
  min-height: 25px;

  .swiper{
    position:fixed;
    margin:auto;
    left:0;
    right:0;
    top:0;
    bottom:0;
    width:600px;
    height:400px;
    box-shadow: 0 -0px 10px rgba(0,0,0,.2);
    border: 1px solid #ededed;
    border-radius: 3px;
    background-color: #fff;
    .swiper-all{
      position: static;
      .swiper-el{
        width: 600px;
        height: 400px;
      }
    }
  }
  .close-quick{
    position:fixed;
    top: 0px;
    left: 0px;
    right: 0px;
    bottom: 0px;
    background-color: rgba(240,240,240,.8);
  }

  .swiper{
    position:fixed;
    margin:auto;
    left:0;
    right:0;
    top:0;
    bottom:0;
    width:600px;
    height:400px;
    box-shadow: 0 -0px 10px rgba(0,0,0,.2);
    border: 1px solid #ededed;
    border-radius: 3px;
    .swiper-all{
      position: static;
      padding:10px 20px;
      .swiper-el{
        width: 600px;
        height: 400px;
      }
    }
  }
  p{
    padding:0px;
    margin:0px;
    text-align:left;
    font-size:14px;
    color:rgb(51,51,51);
  }
  .add{
    cursor: pointer;
    margin: 0;
    padding: 0;
    width: 100%;
    height: 100%;
  }
}
</style>
