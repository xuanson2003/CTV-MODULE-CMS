using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Common
{
    public class Consts
    {
        public const string DefaultTenant = "Default";
        public const string DefaultApp = "Default";
        public const string SecuritySalt = "doeocgn";
        public struct ClaimTypes
        {
            public const string TenantAppCode = "TenantAppCode";
            public const string TenantId = "TenantId";
            public const string TenantCode = "TenantCode";
            public const string AppId = "AppId";
            public const string AppCode = "AppCode";
        }
        public struct Message
        {
            public const string SERVICE_REQUEST_UNEXISTS = "Yêu cầu dịch vụ không tồn tại !";
            public const string SERVICE_LOGIN_SUCCESS = "Đăng nhập thành công !";
            public const string SERVICE_PASS_INCORRECT = "Mật khẩu không đúng !";
            public const string SERVICE_USERNAME_UNACTIVE = "Tài khoản chưa kích hoạt !";
            public const string SERVICE_STORE_UNACTIVE = "Kho lưu trữ không hoạt động !";
            public const string SERVICE_FOLDER_UNACTIVE = "Thư mục không hoạt động !";
            public const string SERVICE_RECORD_UNEXISTS = "Bản ghi không tồn tại !";
            public const string SERVICE_FILE_UNEXISTS = "File không tồn tại !";
            public const string SERVICE_EVENT_NOTIFICATION_UNEXISTS = "Sự kiện thông báo không tồn tại !";
            public const string SERVICE_USERNAME_UNEXISTS = "Tài khoản không tồn tại !";
            public const string SERVICE_FOLDER_UNEXISTS = "Thư mục không tồn tại !";
            public const string SERVICE_REFTYPE_UNEXISTS = "RefType không tồn tại !";
            public const string SERVICE_ORGAN_UNEXISTS = "Cơ cấu tổ chức không tồn tại !";
            public const string SERVICE_TENANT_UNEXISTS_REQUIRE = "Yêu cầu truy cập đối tượng thuê không tồn tại !";
            public const string SERVICE_APP_UNEXISTS_REQUIRE = "Yêu cầu truy cập ứng dụng không tồn tại !";
            public const string SERVICE_USERNAME_UNEXISTS_IN_TENANT = "Tài khoản không tồn tại trong đối tượng thuê !";
            public const string SERVICE_USERNAME_UNEXISTS_IN_APP = "Tài khoản không tồn tại trong ứng dụng !";
            public const string SERVICE_SUCCESS = "Xử lý thành công !";
            public const string SERVICE_ERROR = "Xử lý thất bại !";
            public const string SERVICE_DUPLICATE_USER = "Tài khoản đã tồn tại !";
        }
        public struct RecordStatus
        {
            public const string RELEASED = "R";
            public const string CLOSED = "C";
        }
        public struct RecordAccessLevel
        {
            public const string MYSELF = "MS";
            public const string GLOBAL_ALL = "GA";
            public const string GLOBAL_SELF = "GS";
            public const string LOCAL_SELF = "LS";
            public const string PARENT_CHILD = "PC";
        }

        public static string[] NotificationType = new string[] { "email", "sms", "push" };

        public struct UserType
        {
            public const string System = "system";
            public const string Internal = "internal";
            public const string External = "external";
        }

        public struct OrganizationType
        {
            public const string Org = "Org";
            public const string BU = "BU";
        }

        public struct DataType
        {
            public const string Int = "Int";
            public const string Decimal = "Decimal";
            public const string DateTime = "DateTime";
            public const string Varchar = "Varchar";
            public const string VarcharMax = "VarcharMax";
            public const string Text = "Text";
            public const string Boolean = "Boolean";
        }
    }
}
