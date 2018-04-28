using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hx.CShop.ApiServices.Admins.WebApi.Models {
    public class FakeMenuProvider {

        public static List<MenuResponse> GetMenus () {
            var str = @"[
        {
            ""Text"": ""首页"",
            ""Level"": 1,
            ""DefaultLink"": ""/dashboard"",
            ""Children"": [
                {
                    ""Text"": ""系统首页"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""工作台"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""账户信息"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""充值记录"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""消费记录"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        }
                    ]
                }
            ]
        },
        {
            ""Text"": ""订单"",
            ""Level"": 1,
            ""DefaultLink"": ""/order/list"",
            ""Children"": [
                {
                    ""Text"": ""订单管理"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""查询订单"",
                            ""Level"": 3,
                            ""Link"": ""/order/list"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""新增订单"",
                            ""Level"": 3,
                            ""Link"": ""/order/new"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""待审审核"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""待拆分"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        },
                        {
                            ""Text"": ""待合并"",
                            ""Level"": 3,
                            ""Link"": ""/dashboard"",
                            ""Icon"": ""icon-speedometer""
                        }
                    ]
                }
            ]
        },
        {
            ""Text"": ""Demo"",
            ""Level"": 1,
            ""DefaultLink"": ""/demo/usermanager/userlist"",
            ""Children"": [
                {
                    ""Text"": ""RSDEMO"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""RSJS"",
                            ""Level"": 3,
                            ""Link"": ""/demo/RSJS"",
                            ""Icon"": ""icon-chemistry""
                        }
                    ]
                },
                {
                    ""Text"": ""基础实例"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""基础元素"",
                            ""Level"": 3,
                            ""Icon"": ""icon-chemistry"",
                            ""Children"": [
                                {
                                    ""Text"": ""按钮"",
                                    ""Link"": ""/elements/buttons"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Notification"",
                                    ""Link"": ""/elements/notification"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Modal"",
                                    ""Link"": ""/elements/modal"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Tree Antd"",
                                    ""Link"": ""/elements/tree-antd"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Sortable"",
                                    ""Link"": ""/elements/sortable"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Spin"",
                                    ""Link"": ""/elements/spin"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Dropdown"",
                                    ""Link"": ""/elements/dropdown"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Grid"",
                                    ""Link"": ""/elements/grid""
                                },
                                {
                                    ""Text"": ""Grid Masonry"",
                                    ""Link"": ""/elements/gridmasonry"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Typography"",
                                    ""Link"": ""/elements/typography"",
                                    ""Level"": 3,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Font Icons"",
                                    ""Link"": ""/elements/Iconsfont"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""Colors"",
                                    ""Link"": ""/elements/colors"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                }
                            ]
                        },
                        {
                            ""Text"": ""表单"",
                            ""Level"": 3,
                            ""Icon"": ""icon-chemistry"",
                            ""Children"": [
                                {
                                    ""Text"": ""标准"",
                                    ""Link"": ""/demo/forms/standard"",
                                    ""Level"": 3,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""上传"",
                                    ""Link"": ""/demo/forms/upload"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""上传组件"",
                                    ""Link"": ""/demo/forms/uploadgroupdemo"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""下载文件"",
                                    ""Link"": ""/demo/forms/downfile"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                },
                                {
                                    ""Text"": ""图片裁剪"",
                                    ""Link"": ""/demo/forms/cropper"",
                                    ""Level"": 4,
                                    ""Icon"": ""icon-chemistry""
                                }
                            ]
                        }
                    ]
                },
                {
                    ""Text"": ""用户管理"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""用户列表"",
                            ""Link"": ""/demo/usermanager/userlist"",
                            ""Level"": 3,
                            ""Icon"": ""icon-chemistry""
                        }
                    ]
                }
            ]
        },
        {
            ""Text"": ""基础"",
            ""Level"": 1,
            ""DefaultLink"": ""/basic/organization/organizationlist"",
            ""Children"": [
                {
                    ""Text"": ""组织机构"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""查询组织"",
                            ""Link"": ""/basic/organization/organizationlist"",
                            ""Level"": 3,
                            ""Icon"": ""icon-chemistry""
                        }
                    ]
                },
                {
                    ""Text"": ""菜单管理"",
                    ""Level"": 2,
                    ""Children"": [
                        {
                            ""Text"": ""查询菜单"",
                            ""Link"": ""/basic/menumanager/list"",
                            ""Level"": 3,
                            ""Icon"": ""icon-chemistry""
                        }
                    ]
                }
            ]
        }
    ]";
            return JsonConvert.DeserializeObject<List<MenuResponse>> (str);
        }
    }
}