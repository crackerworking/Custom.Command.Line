﻿using Custom.CLI.Commands;

using Spectre.Console.Cli;

namespace Custom.CLI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var app = new CommandApp();
            app.Configure(config =>
            {
                config.AddCommand<GenCommand>("gen").WithDescription("生成测试数据");
                config.AddCommand<DateConvertCommand>("dc").WithDescription("日期转换时间戳");
                config.AddCommand<TimestampConvertCommand>("tc").WithDescription("时间戳转换日期");
                config.AddCommand<StringViewCommand>("sv").WithDescription("剪贴板中换行使用逗号拼接");
            });
            await app.RunAsync(args);
        }
    }
}