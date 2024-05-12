/***********************************************************************************************
*                                                                                              *
*                           Project Name : hatuki-block-commentator                            *
*                                                                                              *
*                                     File Name :  App.cs                                      *
*                                                                                              *
*                                     Programmer : Hatuki                                      *
*                                                                                              *
*                                     Create : 2024-05-12                                      *
*                                                                                              *
*                                     Update : 2024-05-13                                      *
*                                                                                              *
*----------------------------------------------------------------------------------------------*
*                                                                                              *
*                        Dealing with console logic and command system.                        *
*                                                                                              *
*==============================================================================================*/


using HatukiBlockCommentator.Abstract;
using HatukiBlockCommentator.Utils;
using System.Diagnostics;
using System.Reflection;


namespace HatukiBlockCommentator;

internal class App
{
    internal readonly ICommandDealer[] dealers = [
        new VersionDealer(),
        new HelperDealer(),
        new GeneratorDealer(),
        new DefaultDealer(),
    ];

    private App() { }

    internal static App CreateInstance() => new App();

    internal void Run(string[] args)
    {
#if DEBUG
        args = [
            //"-t",
            //"c:\\users\\hanyo\\desktop\\demo.csv",
            //"c:\\users\\hanyo\\desktop\\demo.txt",
            //"--ver"
            "-h"
        ];
#endif
        foreach (var dealer in dealers) { if (dealer.Deal(args)) break; }
    }
}


internal static class Kei { public static string KeiSay(string? s, string m) => $"{s ?? string.Empty} \n\n{m}\n\n不看说明文档的东西，爬!"; }
internal static class KeiWords
{
    public readonly static string[] VERSION_KEIS = ["-V", "--ver", "--version"];
    public readonly static string[] HELP_KEIS = ["-?", "-h", "--help", "--man"];
    public readonly static string[] GENERATE_KEIS = ["-t", "-tar", "-target"];
    public readonly static string[] PARSER_KEIS = ["-s", "-src", "-source"];
    public readonly static string[] T_GENERATOR_KEIS = ["-s_tpl", "--source_template"];
    public readonly static string[] T_PARSER_KEIS = ["-t_tpl", "--target_template"];
    public readonly static string[] PYTHON_KEIS = ["python", "py", "#"];
    public readonly static string[] IS_MEMBER_KEIS = ["m", "mem", "member", "true"];
    public readonly static string[] IS_EVENT_KEIS = ["e", "ev", "evt", "event", "events"];
    public readonly static string[] IS_FIELD_KEIS = ["f", "fd", "field", "fields"];
    public readonly static string[] IS_METHOD_KEIS = ["m", "mt", "met", "mtd", "method", "methods"];
    public static void KeiSay() => Console.WriteLine(string.Join('\n', [
        string.Empty.PadLeft(30, '='),
        $"|| Ciallo～(∠·ω< )⌒★   ||",
        $"||{string.Empty.PadLeft(26, '-')}||",
        "|| 请输入正确格式的指令喵~  ||",
        string.Empty.PadLeft(30, '='),
    ]));
    public static void KeiHarry(string path) => Console.WriteLine(string.Join('\n', [
        string.Empty.PadLeft(30, '='),
        $"|| Ciallo～(∠·ω< )⌒★   ||",
        $"||{string.Empty.PadLeft(26, '-')}||",
        "|| 注释已保存到以下路径喵~  ||",
        string.Empty.PadLeft(30, '='),
        path,
        string.Empty.PadLeft(path.Length, '-'),
    ]));
    public readonly static string VERSION_WORDS = string.Join('\n', [
        string.Empty.PadLeft(32, '='),
        $"||   Ciallo～(∠·ω< )⌒★   ||",
        $"||{string.Empty.PadLeft(28, '-')}||",
        $"|| 当前的 HBC 版本为: {typeof(KeiWords).Assembly.GetName().Version?.ToString()} ||",
        string.Empty.PadLeft(32, '='),
    ]);
    public readonly static string HELPER_WORDS = string.Join('\n', [
        string.Empty.PadLeft(30, '='),
        $"|| Ciallo～(∠·ω< )⌒★   ||",
        $"||{string.Empty.PadLeft(26, '-')}||",
        "|| HBC实装的命令用法如下喵~ ||",
        string.Empty.PadLeft(30, '='),
        string.Empty,
        $"[+] --version: 获得当前程序的版本.",
        $"[+] --help: 获得命令列表.",
        $"[+] -tar csv_path txt_path: 根据路径为csv_path的csv文件生成注释块.\n",
        ">> For more information, please visit: https://github.com/HanyoVladScarlet/hatuki-block-commentator/blob/main/README.md\n",
        string.Empty.PadLeft(30, '-'),
        //$"Parse from comments : {string.Join('\\', GENERATE_KEIS)} + [target_path] + [source_path]",
    ]);
    public static string Read(string fromPath)
    {
        using var fs = File.OpenRead(fromPath);
        var buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
    public static void Write(string toPath, string content)
    {
        if (File.Exists(toPath)) File.Delete(toPath);
        using var fs = File.OpenWrite(toPath);
        //Console.WriteLine($"Content : {content}");
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        fs.Write(buffer, 0, buffer.Length);
    }
}

internal class DefaultDealer : ICommandDealer { bool ICommandDealer.Deal(string[] args) { KeiWords.KeiSay(); return true; } }
internal class HelperDealer : ICommandDealer
{

    bool ICommandDealer.Deal(string[] args)
    {
        var res = false;
        try
        {
            if (args.Length == 0) return res;
            res = KeiWords.HELP_KEIS.Any(x => x == args[0]);
            if (res) Console.WriteLine(KeiWords.HELPER_WORDS);
        }
        catch (Exception e) { Console.WriteLine(Kei.KeiSay(e.StackTrace, e.Message)); res = true; }
        return res;
    }
}
internal class VersionDealer : ICommandDealer
{
    bool ICommandDealer.Deal(string[] args)
    {
        var res = false;
        try
        {
            if (args.Length == 0) return res;
            res = KeiWords.VERSION_KEIS.Any(x => x == args[0]);
            if (res) Console.WriteLine(KeiWords.VERSION_WORDS);
        }
        catch (Exception e) { Console.WriteLine(Kei.KeiSay(e.StackTrace, e.Message)); res = true; }

        return res;
    }
}

internal class GeneratorDealer : ICommandDealer
{
    bool ICommandDealer.Deal(string[] args)
    {
        // args[0]: -t
        // args[1]: csv file
        // args[2]: comment file.
        // 懒狗从不在变量声名上耽误功夫!
        var res = false;
        try
        {
            if (args.Length < 3) return res;
            res = KeiWords.GENERATE_KEIS.Any(x => x == args[0]);

            var lines = KeiWords.Read(args[1]).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var parts_0 = lines[0].Split(',');
            var parts_1 = lines[1].Split(",");
            var parts_2 = lines[2].Split(",");
            var parts_3 = new string[] { string.Empty, string.Empty, string.Empty };
            if (lines.Length >= 4) parts_3 = lines[3].Split(",");
            var isMember = KeiWords.IS_MEMBER_KEIS.Any(x => x == parts_0[2].Trim());
            var succCreate = DateTime.TryParse(parts_2[1], out var create);
            var succUpdate = DateTime.TryParse(parts_2[2], out var update);


            if (isMember) KeiWords.Write(args[2], BlockCommentator.CreateInstance()
                    // Line_0.
                    .SetIsPython(KeiWords.PYTHON_KEIS.Any(x => x == parts_0[0]))
                    .SetWidth(int.Parse(parts_0[1]))
                    .SetIsMember(isMember)
                    // Line_1
                    .SetUpdater(parts_1[0].Trim())
                    .SetUpdatee(parts_1[1].Trim())
                    .SetLabel(parts_1[2].Trim())
                    // Line_2
                    .SetProgrammer(parts_2[0].Trim())
                    .SetCreate(succCreate ? create : DateTime.Now)
                    .SetUpdate(succUpdate ? update : DateTime.Now)
                    // Line_3.
                    .SetMemberName(parts_3[0].Trim())
                    .SetWarning(parts_3[1].Trim())
                    .SetDescription(parts_3[2].Trim())
                    .Generate());
            else
            {
                var bc = BlockCommentator.CreateInstance();
                // Lines_after_3
                foreach (var line in lines[3..^0])
                {
                    var parts = line.Split(",");
                    if (KeiWords.IS_EVENT_KEIS.Any(x => x == parts[0])) bc.AppendEvent(parts[1].Trim(), parts[2].Trim());
                    if (KeiWords.IS_FIELD_KEIS.Any(x => x == parts[0])) bc.AppendField(parts[1].Trim(), parts[2].Trim());
                    if (KeiWords.IS_METHOD_KEIS.Any(x => x == parts[0])) bc.AppendMethod(parts[1].Trim(), parts[2].Trim());
                }
                KeiWords.Write(args[2],
                    // Line_0.
                    bc.SetIsPython(KeiWords.PYTHON_KEIS.Any(x => x == parts_0[0]))
                    .SetWidth(int.Parse(parts_0[1]))
                    .SetIsMember(isMember)
                    // Line_1
                    .SetProjectName(parts_1[0].Trim())
                    .SetFileName(parts_1[1])
                    .SetDescription(parts_1[2].Trim())
                    // Line_2
                    .SetProgrammer(parts_2[0].Trim())
                    .SetCreate(succCreate ? create : DateTime.Now)
                    .SetUpdate(succUpdate ? update : DateTime.Now)
                    .Generate()); ;
            }
            KeiWords.KeiHarry(args[2]);
            res = true;
        }
        catch (Exception e) { Console.WriteLine(Kei.KeiSay(e.StackTrace, e.Message)); res = true; }

        return res;
    }
}
