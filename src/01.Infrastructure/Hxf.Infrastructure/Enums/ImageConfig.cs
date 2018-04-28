using System.Collections.Generic;

namespace Hxf.Infrastructure.Enums {
    public class Thumbs {
        /// <summary>
        /// 缩略图的类型
        /// </summary>
        public ThumbType ThType { get; set; }

        /// <summary>
        /// 缩略图宽度.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 缩略图高度.
        /// </summary>
        public int Height { get; set; }
    }

    public class ImageConfig {
        /// <summary>
        /// 是否启用图片压缩
        /// </summary>
        public bool Compress { get; set; }
        /// <summary>
        /// 图片压缩宽度
        /// </summary>
        public int CompressWidth { get; set; }
        /// <summary>
        /// 图片压缩高度
        /// </summary>
        public int CompressHeight { get; set; }

        /// <summary>
        /// 允许上传文件的扩展名.
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 生成多缩略图配置.
        /// </summary>
        public List<Thumbs> MutilThumb { get; set; }
        /// <summary>
        /// 缩略图是否加水印
        /// </summary>
        public bool ThumbWaterMark { get; set; }
        /// <summary>
        /// 是否生成缩略图
        /// </summary>
        public bool isThumb { get; set; }
        /// <summary>
        /// 缩略图宽度
        /// </summary>
        public int ThumbWidth { get; set; }
        /// <summary>
        /// 缩略图高度
        /// </summary>
        public int ThumbHeight { get; set; }
        /// <summary>
        /// 缩略图生成类型
        /// </summary>
        public ThumbType ThType { get; set; }
        /// <summary>
        /// 是否更改文件名
        /// </summary>
        public bool isChangeName { get; set; }
        /// <summary>
        /// 是否加水印
        /// </summary>
        public bool WaterMark { get; set; }
        /// <summary>
        /// 水印位置
        /// </summary>
        public WaterMarkPosition WWPostion { get; set; }
        /// <summary>
        /// 水印类型
        /// </summary>
        public WaterMarkType WWType { get; set; }

        /// <summary>
        /// 水印文本
        /// </summary>
        public string WWText { get; set; }
        /// <summary>
        /// 文字大小
        /// </summary>
        public string FontSizes { get; set; }
        /// <summary>
        /// 文字样式
        /// </summary>
        public string FontFamily { get; set; }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public FontColor FontColor { get; set; }

        /// <summary>
        /// 水印图片地址
        /// </summary>
        public string WWImage { get; set; }

        /// <summary>
        /// 上传目录
        /// </summary>
        public string UploadDir { get; set; }
        /// <summary>
        /// 按日期分目录
        /// </summary>
        public bool isDateDir { get; set; }
        /// <summary>
        /// 按类型分目录
        /// </summary>
        public bool isTypeDir { get; set; }
        /// <summary>
        /// 上传文件类型
        /// </summary>
        public string FileTypes { get; set; }
        /// <summary>
        /// 文件大小限制
        /// </summary>
        public decimal FileSizeLimit { get; set; }
        /// <summary>
        /// 上传大小限制
        /// </summary>
        public decimal UploadSizeLimit { get; set; }
        /// <summary>
        /// 队列限制
        /// </summary>
        public int QueueLimit { get; set; }

        /// <summary>
        /// 图片上传处理地址
        /// </summary>
        public string UploadUrl { get; set; }
        /// <summary>
        /// Post参数设置
        /// </summary>
        public string PostParameters { get; set; }
        /// <summary>
        /// Query参数设置
        /// </summary>
        public string QueryParameters { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// 资源目录
        /// </summary>
        public string ResourceDir { get; set; }
        /// <summary>
        /// Flash URL 地址
        /// </summary>
        public string FlashUrl { get; set; }
        /// <summary>
        /// 按钮宽度
        /// </summary>
        public int ButtonWidth { get; set; }
        /// <summary>
        /// 按钮高度
        /// </summary>
        public int ButtonHeight { get; set; }
        /// <summary>
        /// 按钮图片地址
        /// </summary>
        public string ButtonImgUrl { get; set; }
        /// <summary>
        /// 按钮文本
        /// </summary>
        public string ButtonText { get; set; }
        /// <summary>
        /// 是否开启调试
        /// </summary>
        public bool Debug { get; set; }
    }
}
