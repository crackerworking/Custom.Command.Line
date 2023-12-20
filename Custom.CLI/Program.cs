using Custom.Cli;
using Custom.Cli.Commands;

var app = new CommandApp();
app.Add<GenCommand>("gen").WithDescription("生成测试数据");
app.Add<LenCommand>("len").WithDescription("字符串长度");
app.Add<RegexCommand>("reg").WithDescription("正则匹配");
app.Add<ImproveCommand>("imp").WithDescription("励志短句");
app.Add<DateConvertCommand>("dc").WithDescription("日期转换时间戳");
app.Add<TimestampConvertCommand>("tc").WithDescription("时间戳转换日期");
app.Add<JsonToObjectConvertCommand>("joc").WithDescription("剪贴板中JSON转换C#对象");
app.Add<JsonViewCommand>("jv").WithDescription("剪贴板中JSON格式化");
app.Add<StringViewCommand>("sv").WithDescription("剪贴板中换行使用逗号拼接");
await app.StartAsync(args);