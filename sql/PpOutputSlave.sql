use Laplace_PRD;

-- oph从表菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('oph从表', 1091, 999, lower('PpOutputSlave'), 'production/PpOutputSlave', 0, 0, 'C', '0', '0', 'pp:outputslave:list', 'icon1', 'system', GETDATE(), 'menu.PpOutputSlave');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:outputslave:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:outputslave:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:outputslave:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:outputslave:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:outputslave:export', '', 'system', GETDATE());


SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;



-- oph从表多语言
INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331091001,'zh-cn', 'menu.PpOutputSlave', 'oph从表', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331091002,'en', 'menu.PpOutputSlave', 'oph从表', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331091003,'ja', 'menu.PpOutputSlave', 'oph从表', GETDATE());