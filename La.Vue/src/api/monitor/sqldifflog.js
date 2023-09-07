import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
 * 数据差异日志分页查询
 * @param {查询条件} data
 */
export function listSysSqldifflog(query) {
  return request({
    url: 'monitor/SysSqldifflog/list',
    method: 'get',
    params: query
  })
}

/**
 * 删除数据差异日志
 * @param {主键} pid
 */
export function delSysSqldifflog(pid) {
  return request({
    url: 'monitor/SysSqldifflog/' + pid,
    method: 'delete'
  })
}
// 导出数据差异日志
export async function exportSysSqldifflog(query) {
  await downFile('monitor/SysSqldifflog/export', { ...query })
}
