namespace Hxf.Infrastructure.Enums {
    #region 图片业务种类
    public enum ImageCategory {
        Product, User, Order, System
    }
    #endregion

    #region 水印类型
    /// <summary>
    /// 水印类型
    /// </summary>
    public enum WaterMarkType {
        /// <summary>
        /// 文本类型
        /// </summary>
        Text,
        /// <summary>
        /// 图片类型
        /// </summary>
        Image
    }
    #endregion

    #region 水印的位置
    /// <summary>
    /// 水印的位置
    /// </summary>
    public enum WaterMarkPosition {
        /// <summary>
        /// 上左
        /// </summary>
        TOP_LEFT,
        /// <summary>
        /// 顶部中间
        /// </summary>
        TOP_CENTER,
        /// <summary>
        /// 上右
        /// </summary>
        TOP_RIGHT,
        /// <summary>
        /// 中左
        /// </summary>
        MIDDLE_LEFT,
        /// <summary>
        /// 正中间
        /// </summary>
        MIDDLE_CENTER,
        /// <summary>
        /// 中右
        /// </summary>
        MIDDLE_RIGHT,
        /// <summary>
        /// 下左
        /// </summary>
        BOTTOM_LEFT,

        /// <summary>
        /// 下中
        /// </summary>
        BOTTOM_CENTER,
        /// <summary>
        /// 下右
        /// </summary>
        BOTTOM_RIGHT

    }
    #endregion

    #region 缩略图类型
    /// <summary> 
    /// 缩略图类型
    /// </summary>
    public enum ThumbType {
        /// <summary>
        /// 以宽为准
        /// </summary>
        WIDTH,
        /// <summary>
        /// 以高为准
        /// </summary>
        HEIGHT,
        /// <summary>
        /// 裁切
        /// </summary>
        CUT,
        /// <summary>
        /// 自动
        /// </summary>
        AUTO
    }
    #endregion

    #region 已知的系统颜色
    /// <summary>
    /// 已知的系统颜色
    /// </summary>
    public enum FontColor {
        /// <summary>
        /// ActiveBorder
        /// </summary>
        ActiveBorder,
        /// <summary>
        /// ActiveCaption
        /// </summary>
        ActiveCaption,
        /// <summary>
        /// ActiveCaptionText
        /// </summary>
        ActiveCaptionText,
        /// <summary>
        /// AppWorkspace
        /// </summary>
        AppWorkspace,
        /// <summary>
        /// Control
        /// </summary>
        Control,
        /// <summary>
        /// ControlDark
        /// </summary>
        ControlDark,
        /// <summary>
        /// ControlDarkDark
        /// </summary>
        ControlDarkDark,
        /// <summary>
        /// ControlLight
        /// </summary>
        ControlLight,
        /// <summary>
        /// ControlLightLight
        /// </summary>
        ControlLightLight,
        /// <summary>
        /// ControlText
        /// </summary>
        ControlText,
        /// <summary>
        /// Desktop
        /// </summary>
        Desktop,
        /// <summary>
        /// GrayText
        /// </summary>
        GrayText,
        /// <summary>
        /// Highlight
        /// </summary>
        Highlight,
        /// <summary>
        /// HighlightText
        /// </summary>
        HighlightText,
        /// <summary>
        /// HotTrack
        /// </summary>
        HotTrack,
        /// <summary>
        /// InactiveBorder
        /// </summary>
        InactiveBorder,
        /// <summary>
        /// InactiveCaption
        /// </summary>
        InactiveCaption,
        /// <summary>
        /// InactiveCaptionText
        /// </summary>
        InactiveCaptionText,
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// InfoText
        /// </summary>
        InfoText,
        /// <summary>
        /// Menu
        /// </summary>
        Menu,
        /// <summary>
        /// MenuText
        /// </summary>
        MenuText,
        /// <summary>
        /// ScrollBar
        /// </summary>
        ScrollBar,
        /// <summary>
        /// Window
        /// </summary>
        Window,
        /// <summary>
        /// WindowFrame
        /// </summary>
        WindowFrame,
        /// <summary>
        /// WindowText
        /// </summary>
        WindowText,
        /// <summary>
        /// Transparent
        /// </summary>
        Transparent,
        /// <summary>
        /// AliceBlue
        /// </summary>
        AliceBlue,
        /// <summary>
        /// AntiqueWhite
        /// </summary>
        AntiqueWhite,
        /// <summary>
        /// Aqua
        /// </summary>
        Aqua,
        /// <summary>
        /// Aquamarine
        /// </summary>
        Aquamarine,
        /// <summary>
        /// Azure
        /// </summary>
        Azure,
        /// <summary>
        /// Beige
        /// </summary>
        Beige,
        /// <summary>
        /// Bisque
        /// </summary>
        Bisque,
        /// <summary>
        /// Black
        /// </summary>
        Black,
        /// <summary>
        /// BlanchedAlmond
        /// </summary>
        BlanchedAlmond,
        /// <summary>
        /// Blue
        /// </summary>
        Blue,
        /// <summary>
        /// BlueViolet
        /// </summary>
        BlueViolet,
        /// <summary>
        /// Brown
        /// </summary>
        Brown,
        /// <summary>
        /// BurlyWood
        /// </summary>
        BurlyWood,
        /// <summary>
        /// CadetBlue
        /// </summary>
        CadetBlue,
        /// <summary>
        /// Chartreuse
        /// </summary>
        Chartreuse,
        /// <summary>
        /// Chocolate
        /// </summary>
        Chocolate,
        /// <summary>
        /// Coral
        /// </summary>
        Coral,
        /// <summary>
        /// CornflowerBlue
        /// </summary>
        CornflowerBlue,
        /// <summary>
        /// Cornsilk
        /// </summary>
        Cornsilk,
        /// <summary>
        /// Crimson
        /// </summary>
        Crimson,
        /// <summary>
        /// Cyan
        /// </summary>
        Cyan,
        /// <summary>
        /// DarkBlue
        /// </summary>
        DarkBlue,
        /// <summary>
        /// DarkCyan
        /// </summary>
        DarkCyan,
        /// <summary>
        /// DarkGoldenrod
        /// </summary>
        DarkGoldenrod,
        /// <summary>
        /// DarkGray
        /// </summary>
        DarkGray,
        /// <summary>
        /// DarkGreen
        /// </summary>
        DarkGreen,
        /// <summary>
        /// DarkKhaki
        /// </summary>
        DarkKhaki,
        /// <summary>
        /// DarkMagenta
        /// </summary>
        DarkMagenta,
        /// <summary>
        /// DarkOliveGreen
        /// </summary>
        DarkOliveGreen,
        /// <summary>
        /// DarkOrange
        /// </summary>
        DarkOrange,
        /// <summary>
        /// DarkOrchid
        /// </summary>
        DarkOrchid,
        /// <summary>
        /// DarkRed
        /// </summary>
        DarkRed,
        /// <summary>
        /// DarkSalmon
        /// </summary>
        DarkSalmon,
        /// <summary>
        /// DarkSeaGreen
        /// </summary>
        DarkSeaGreen,
        /// <summary>
        /// DarkSlateBlue
        /// </summary>
        DarkSlateBlue,
        /// <summary>
        /// DarkSlateGray
        /// </summary>
        DarkSlateGray,
        /// <summary>
        /// DarkTurquoise
        /// </summary>
        DarkTurquoise,
        /// <summary>
        /// DarkViolet
        /// </summary>
        DarkViolet,
        /// <summary>
        /// DeepPink
        /// </summary>
        DeepPink,
        /// <summary>
        /// DeepSkyBlue
        /// </summary>
        DeepSkyBlue,
        /// <summary>
        /// DimGray
        /// </summary>
        DimGray,
        /// <summary>
        /// DodgerBlue
        /// </summary>
        DodgerBlue,
        /// <summary>
        /// Firebrick
        /// </summary>
        Firebrick,
        /// <summary>
        /// FloralWhite
        /// </summary>
        FloralWhite,
        /// <summary>
        /// ForestGreen
        /// </summary>
        ForestGreen,
        /// <summary>
        /// Fuchsia
        /// </summary>
        Fuchsia,
        /// <summary>
        /// Gainsboro
        /// </summary>
        Gainsboro,
        /// <summary>
        /// GhostWhite
        /// </summary>
        GhostWhite,
        /// <summary>
        /// Gold
        /// </summary>
        Gold,
        /// <summary>
        /// Goldenrod
        /// </summary>
        Goldenrod,
        /// <summary>
        /// Gray
        /// </summary>
        Gray,
        /// <summary>
        /// Green
        /// </summary>
        Green,
        /// <summary>
        /// GreenYellow
        /// </summary>
        GreenYellow,
        /// <summary>
        /// Honeydew
        /// </summary>
        Honeydew,
        /// <summary>
        /// HotPink
        /// </summary>
        HotPink,
        /// <summary>
        /// IndianRed
        /// </summary>
        IndianRed,
        /// <summary>
        /// Indigo
        /// </summary>
        Indigo,
        /// <summary>
        /// Ivory
        /// </summary>
        Ivory,
        /// <summary>
        /// Khaki
        /// </summary>
        Khaki,
        /// <summary>
        /// Lavender
        /// </summary>
        Lavender,
        /// <summary>
        /// LavenderBlush
        /// </summary>
        LavenderBlush,
        /// <summary>
        /// LawnGreen
        /// </summary>
        LawnGreen,
        /// <summary>
        /// LemonChiffon
        /// </summary>
        LemonChiffon,
        /// <summary>
        /// LightBlue
        /// </summary>
        LightBlue,
        /// <summary>
        /// LightCoral
        /// </summary>
        LightCoral,
        /// <summary>
        /// LightCyan
        /// </summary>
        LightCyan,
        /// <summary>
        /// LightGoldenrodYellow
        /// </summary>
        LightGoldenrodYellow,
        /// <summary>
        /// LightGray
        /// </summary>
        LightGray,
        /// <summary>
        /// LightGreen
        /// </summary>
        LightGreen,
        /// <summary>
        /// LightPink
        /// </summary>
        LightPink,
        /// <summary>
        /// LightSalmon
        /// </summary>
        LightSalmon,
        /// <summary>
        /// LightSeaGreen
        /// </summary>
        LightSeaGreen,
        /// <summary>
        /// LightSkyBlue
        /// </summary>
        LightSkyBlue,
        /// <summary>
        /// LightSlateGray
        /// </summary>
        LightSlateGray,
        /// <summary>
        /// LightSteelBlue
        /// </summary>
        LightSteelBlue,
        /// <summary>
        /// LightYellow
        /// </summary>
        LightYellow,
        /// <summary>
        /// Lime
        /// </summary>
        Lime,
        /// <summary>
        /// LimeGreen
        /// </summary>
        LimeGreen,
        /// <summary>
        /// Linen
        /// </summary>
        Linen,
        /// <summary>
        /// Magenta
        /// </summary>
        Magenta,
        /// <summary>
        /// Maroon
        /// </summary>
        Maroon,
        /// <summary>
        /// MediumAquamarine
        /// </summary>
        MediumAquamarine,
        /// <summary>
        /// MediumBlue
        /// </summary>
        MediumBlue,
        /// <summary>
        /// MediumOrchid
        /// </summary>
        MediumOrchid,
        /// <summary>
        /// MediumPurple
        /// </summary>
        MediumPurple,
        /// <summary>
        /// MediumSeaGreen
        /// </summary>
        MediumSeaGreen,
        /// <summary>
        /// MediumSlateBlue
        /// </summary>
        MediumSlateBlue,
        /// <summary>
        /// MediumSpringGreen
        /// </summary>
        MediumSpringGreen,
        /// <summary>
        /// MediumTurquoise
        /// </summary>
        MediumTurquoise,
        /// <summary>
        /// MediumVioletRed
        /// </summary>
        MediumVioletRed,
        /// <summary>
        /// MidnightBlue
        /// </summary>
        MidnightBlue,
        /// <summary>
        /// MintCream
        /// </summary>
        MintCream,
        /// <summary>
        /// MistyRose
        /// </summary>
        MistyRose,
        /// <summary>
        /// Moccasin
        /// </summary>
        Moccasin,
        /// <summary>
        /// NavajoWhite
        /// </summary>
        NavajoWhite,
        /// <summary>
        /// Navy
        /// </summary>
        Navy,
        /// <summary>
        /// OldLace
        /// </summary>
        OldLace,
        /// <summary>
        /// Olive
        /// </summary>
        Olive,
        /// <summary>
        /// OliveDrab
        /// </summary>
        OliveDrab,
        /// <summary>
        /// Orange
        /// </summary>
        Orange,
        /// <summary>
        /// OrangeRed
        /// </summary>
        OrangeRed,
        /// <summary>
        /// Orchid
        /// </summary>
        Orchid,
        /// <summary>
        /// PaleGoldenrod
        /// </summary>
        PaleGoldenrod,
        /// <summary>
        /// PaleGreen
        /// </summary>
        PaleGreen,
        /// <summary>
        /// PaleTurquoise
        /// </summary>
        PaleTurquoise,
        /// <summary>
        /// PaleVioletRed
        /// </summary>
        PaleVioletRed,
        /// <summary>
        /// PapayaWhip
        /// </summary>
        PapayaWhip,
        /// <summary>
        /// PeachPuff
        /// </summary>
        PeachPuff,
        /// <summary>
        /// Peru
        /// </summary>
        Peru,
        /// <summary>
        /// Pink
        /// </summary>
        Pink,
        /// <summary>
        /// Plum
        /// </summary>
        Plum,
        /// <summary>
        /// PowderBlue
        /// </summary>
        PowderBlue,
        /// <summary>
        /// Purple
        /// </summary>
        Purple,
        /// <summary>
        /// Red
        /// </summary>
        Red,
        /// <summary>
        /// RosyBrown
        /// </summary>
        RosyBrown,
        /// <summary>
        /// RoyalBlue
        /// </summary>
        RoyalBlue,
        /// <summary>
        /// SaddleBrown
        /// </summary>
        SaddleBrown,
        /// <summary>
        /// Salmon
        /// </summary>
        Salmon,
        /// <summary>
        /// SandyBrown
        /// </summary>
        SandyBrown,
        /// <summary>
        /// SeaGreen
        /// </summary>
        SeaGreen,
        /// <summary>
        /// SeaShell
        /// </summary>
        SeaShell,
        /// <summary>
        /// Sienna
        /// </summary>
        Sienna,
        /// <summary>
        /// Silver
        /// </summary>
        Silver,
        /// <summary>
        /// SkyBlue
        /// </summary>
        SkyBlue,
        /// <summary>
        /// SlateBlue
        /// </summary>
        SlateBlue,
        /// <summary>
        /// SlateGray
        /// </summary>
        SlateGray,
        /// <summary>
        /// Snow
        /// </summary>
        Snow,
        /// <summary>
        /// SpringGreen
        /// </summary>
        SpringGreen,
        /// <summary>
        /// SteelBlue
        /// </summary>
        SteelBlue,
        /// <summary>
        /// Tan
        /// </summary>
        Tan,
        /// <summary>
        /// Teal
        /// </summary>
        Teal,
        /// <summary>
        /// Thistle
        /// </summary>
        Thistle,
        /// <summary>
        /// Tomato
        /// </summary>
        Tomato,
        /// <summary>
        /// Turquoise
        /// </summary>
        Turquoise,
        /// <summary>
        /// Violet
        /// </summary>
        Violet,
        /// <summary>
        /// Wheat
        /// </summary>
        Wheat,
        /// <summary>
        /// White
        /// </summary>
        White,
        /// <summary>
        /// WhiteSmoke
        /// </summary>
        WhiteSmoke,
        /// <summary>
        /// Yellow
        /// </summary>
        Yellow,
        /// <summary>
        /// YellowGreen
        /// </summary>
        YellowGreen,
        /// <summary>
        /// ButtonFace
        /// </summary>
        ButtonFace,
        /// <summary>
        /// ButtonHighlight
        /// </summary>
        ButtonHighlight,
        /// <summary>
        /// ButtonShadow
        /// </summary>
        ButtonShadow,
        /// <summary>
        /// GradientActiveCaption
        /// </summary>
        GradientActiveCaption,
        /// <summary>
        /// GradientInactiveCaption
        /// </summary>
        GradientInactiveCaption,
        /// <summary>
        /// MenuBar
        /// </summary>
        MenuBar,
        /// <summary>
        /// MenuHighlight
        /// </summary>
        MenuHighlight
    }
    #endregion 

    #region 图片位置
    /// <summary>  
    /// 图片位置  
    /// </summary>  
    public enum ImagePosition {
        /// <summary>
        /// 左上
        /// </summary>
        LeftTop,
        /// <summary>
        /// 左下 
        /// </summary>
        LeftBottom,
        /// <summary>
        /// 右上  
        /// </summary>
        RightTop,
        /// <summary>
        /// 右下  
        /// </summary>
        RigthBottom,
        /// <summary>
        /// 顶部居中  
        /// </summary>
        TopMiddle,
        /// <summary>
        /// 底部居中
        /// </summary>
        BottomMiddle,
        /// <summary>
        /// 中心
        /// </summary>
        Center
    }
    #endregion 
}
