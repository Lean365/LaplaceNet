use Lean365;

-- 机构信息菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by, create_time,menuName_key) 
VALUES ('机构信息', 1100, 999, 'InstInfo', 'office/InstInfo', 0, 0, 'C', '0', '0', 'inst:info:list', 'icon1', 'system', GETDATE(), 'menu.InstInfo');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:query', '', 'system', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:add', '', 'system', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:delete', '', 'system', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:edit', '', 'system', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:export', '', 'system', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'inst:info:import', '', 'system', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 机构信息多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1100001,'zh-cn', 'menu.InstInfo', '机构信息', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1100002,'zh-tw', 'menu.InstInfo', 'TW_机构信息', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1100003,'en', 'menu.InstInfo', 'EN_机构信息', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1100004,'ja', 'menu.InstInfo', 'JA_机构信息', GETDATE());