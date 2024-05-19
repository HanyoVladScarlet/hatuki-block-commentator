/***********************************************************************************************
*                                                                                              *
*                           Project Name : hatuki-block-commentator                            *
*                                                                                              *
*                               File Name :  BlockCommentator.cs                               *
*                                                                                              *
*                                     Programmer : Hatuki                                      *
*                                                                                              *
*                                     Create : 2024-05-12                                      *
*                                                                                              *
*                                     Update : 2024-05-13                                      *
*                                                                                              *
*----------------------------------------------------------------------------------------------*
*                                                                                              *
*                         Core class implementing a generator methods.                         *
*                                                                                              *
*==============================================================================================*/


namespace HatukiBlockCommentator.Utils;

/// <summary>
/// 写了400多行, 真有我的.
/// </summary>
public class BlockCommentator
{
    private BlockCommentator() { }
    public static BlockCommentator CreateInstance() => new BlockCommentator();


    private bool _isPython = false;
    public bool IsPython => _isPython;
    public BlockCommentator SetIsPython(bool isPython)
    {
        _isPython = isPython;
        return this;
    }


    private readonly int MAX_WIDTH = 128;
    private readonly int MIN_WIDTH = 72;
    private readonly int PADDING = 1;
    private int _width = 96;


    public int Width => _width;
    public BlockCommentator SetWidth(int width)
    {
        _width = (width < MAX_WIDTH && width > MIN_WIDTH) ? width : _width;
        return this;
    }


    private bool _isMemberComment = false;
    public bool IsMemberComment => _isMemberComment;
    public BlockCommentator SetIsMember(bool isMemberComment)
    {
        _isMemberComment = isMemberComment;
        return this;
    }


    private string _projectName = "MyDemo";
    public string ProjectName => _projectName;
    public BlockCommentator SetProjectName(string projectName)
    {
        _projectName = projectName;
        return this;
    }

    private string _fileName = "-";
    private string FileName => _fileName;
    public BlockCommentator SetFileName(string filename)
    {
        _fileName = filename;
        return this;
    }


    private DateTime _create = DateTime.MinValue;
    public DateTime Create => _create;
    public BlockCommentator SetCreate(DateTime create)
    {
        _create = create;
        return this;
    }


    private string _description = "-";
    public string Description => _description;
    public BlockCommentator SetDescription(string description)
    {
        _description = description;
        return this;
    }

    private string _warning = "-";
    public string Warning => _warning;
    public BlockCommentator SetWarning(string warning)
    {
        _warning = warning;
        return this;
    }

    private string _label = "-";
    public string Label => _label;
    public BlockCommentator SetLabel(string label)
    {
        _label = label;
        return this;
    }

    private string _memberName = "-";
    public string MemberName => _memberName;
    public BlockCommentator SetMemberName(string name)
    {
        _memberName = name;
        return this;
    }


    private string _programmer = "Anonymous";
    public string Programmer => _programmer;
    public BlockCommentator SetProgrammer(string programmer)
    {
        _programmer = programmer;
        return this;
    }

    public string _updater = "Anonymous";
    public string Updater => _updater;
    public BlockCommentator SetUpdater(string updater)
    {
        _updater = updater;
        return this;
    }


    private DateTime _update = DateTime.MinValue;
    public DateTime Update => _update;
    public BlockCommentator SetUpdate(DateTime update)
    {
        _update = update;
        return this;
    }


    private string _updatee = string.Empty;
    public string Updatee => _updatee;
    public BlockCommentator SetUpdatee(string updatee)
    {
        _updatee = updatee;
        return this;
    }

    private IDictionary<string, string> _eventMap = new Dictionary<string, string>();
    private IDictionary<string, string> _fieldMap = new Dictionary<string, string>();
    private IDictionary<string, string> _methodMap = new Dictionary<string, string>();

    public BlockCommentator AppendEvent(string mName, string mLabel)
    {
        if (_eventMap.ContainsKey(mName)) _eventMap[mName] = mLabel;
        else _eventMap.Add(mName, mLabel);
        return this;
    }
    public BlockCommentator AppendField(string mName, string mLabel)
    {
        if (_eventMap.ContainsKey(mName)) _fieldMap[mName] = mLabel;
        else _fieldMap.Add(mName, mLabel);
        return this;
    }
    public BlockCommentator AppendMethod(string mName, string mLabel)
    {
        if (_eventMap.ContainsKey(mName)) _methodMap[mName] = mLabel;
        else _methodMap.Add(mName, mLabel);
        return this;
    }

    //TODO: Parser -- parse BlockCommentator from generated comment.
    //public static BlockCommentator Parse(string input)
    //{
    //    var bc = new BlockCommentator();

    //    return bc;
    //}


    public string Generate() => ToString();

    public override string ToString() => _isMemberComment ? GenerateMemberComment() : GenerateFileComment();


    /// <summary>
    /// 24岁, 喜欢三元表达式.
    /// </summary>
    public string GenerateMemberComment() => new System.Text.StringBuilder()
        .AppendLine(IsPython ? GetPyHeader() : GetCsHeader())
        .AppendLine(IsPython ? GetPyMiddled(MemberName.Trim()) : GetCsMiddled(MemberName.Trim()))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyMiddled(Description.Trim()) : GetCsMiddled(Description.Trim()))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyLeft($"Created : {Programmer.Trim()} at {Create.ToString("yyyy-MM-dd")}") : GetCsLeft($"Created : {Programmer.Trim()} at {Create.ToString("yyyy-MM-dd")}"))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyLeft($"About: {Label.Trim()}") : GetCsLeft($"About: {Label.Trim()}"))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyLeft($"Updated : {Updater.Trim()} at {Update.ToString("yyyy-MM-dd")}") : GetCsLeft($"Updated : {Updater.Trim()} at {Update.ToString("yyyy-MM-dd")}"))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyLeft($"Modification: {Updatee.Trim()}") : GetCsLeft($"Modification: {Updatee.Trim()}"))
        .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
        .AppendLine(IsPython ? GetPyLeft($"Warning: {Warning.Trim()}") : GetCsLeft($"Warning: {Warning.Trim()}"))
        .AppendLine(IsPython ? GetPyTail() : GetCsTail())
        .ToString();

    /// <summary>
    /// 24岁, 喜欢三元表达式.
    /// </summary>
    public string GenerateFileComment()
    {
        var sb = new System.Text.StringBuilder();

        // Append header block.
        sb.AppendLine(IsPython ? GetPyHeader() : GetCsHeader())
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled($"Project Name : {ProjectName.Trim()}") : GetCsMiddled($"Project Name : {ProjectName.Trim()}"))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled($"File Name : {FileName.Trim()}") : GetCsMiddled($"File Name : {FileName.Trim()}"))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled($"Programmer : {Programmer.Trim()}") : GetCsMiddled($"Programmer : {Programmer.Trim()}"))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled($"Create : {Create.ToString("yyyy-MM-dd")}") : GetCsMiddled($"Create : {Create.ToString("yyyy-MM-dd")}"))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled($"Update : {Update.ToString("yyyy-MM-dd")}") : GetCsMiddled($"Update : {Update.ToString("yyyy-MM-dd")}"))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPySplitter() : GetCsSplitter())
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine())
            .AppendLine(IsPython ? GetPyMiddled(Description.Trim()) : GetCsMiddled(Description.Trim()))
            .AppendLine(IsPython ? GetPyEmptyLine() : GetCsEmptyLine());

        // Append event block.
        if (_eventMap.Count > 0)
        {
            sb.AppendLine(IsPython ? GetPySplitter() : GetCsSplitter())
                .AppendLine(IsPython ? GetPyLeft("Events:") : GetCsLeft("Events:"));
            _eventMap.OrderBy(x => x.Key)
                .Select(x => IsPython ? GetPyLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}") : GetCsLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}"))
                .ToList().ForEach(x => sb.AppendLine(x));
        }

        // Append field block.
        if (_fieldMap.Count > 0)
        {
            sb.AppendLine(IsPython ? GetPySplitter() : GetCsSplitter())
                .AppendLine(IsPython ? GetPyLeft("Fields:") : GetCsLeft("Fields:"));
            _fieldMap.OrderBy(x => x.Key)
                .Select(x => IsPython ? GetPyLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}") : GetCsLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}"))
                .ToList().ForEach(x => sb.AppendLine(x));
        }

        // Append method block.
        if (_methodMap.Count > 0)
        {
            sb.AppendLine(IsPython ? GetPySplitter() : GetCsSplitter())
                .AppendLine(IsPython ? GetPyLeft("Methods:") : GetCsLeft("Methods:"));
            _methodMap.OrderBy(x => x.Key)
                .Select(x => IsPython ? GetPyLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}") : GetCsLeft($"{string.Empty,2}{x.Key.Trim()} -- {x.Value.Trim()}"))
                .ToList().ForEach(x => sb.AppendLine(x));
        }

        // Append 
        sb.Append(IsPython ? GetPyTail() : GetCsTail());

        return sb.ToString();
    }

    private string GetCsHeader()
    {
        var arr = new char[Width];
        Array.Fill(arr, '*');
        arr[0] = '/';
        return new string(arr);
    }

    private string GetPyHeader()
    {
        var arr = new char[Width];
        Array.Fill(arr, '=');
        arr[0] = arr[^1] = '#';
        return new string(arr);
    }
    private string GetCsSplitter()
    {
        var arr = new char[Width];
        Array.Fill(arr, '-');
        arr[0] = arr[^1] = '*';
        return new string(arr);
    }
    private string GetPySplitter()
    {
        var arr = new char[Width];
        Array.Fill(arr, '-');
        arr[0] = arr[^1] = '#';
        return new string(arr);
    }
    private string GetCsTail()
    {
        var arr = new char[Width + 1];
        Array.Fill(arr, '=');
        arr[^1] = '/';
        arr[0] = arr[^2] = '*';
        return new string(arr);
    }
    private string GetPyTail()
    {
        var arr = new char[Width];
        Array.Fill(arr, '=');
        arr[0] = arr[^1] = '#';
        return new string(arr);
    }
    private string GetCsLeft(string input)
    {
        //var len = input.Length;
        //return input;

        if (input.Length < Width - 2 * (PADDING + 1))
            return input
                .PadLeft(input.Length + 1)
                .PadRight(Width - 2)
                .PadLeft(Width - 1, '*')
                .PadRight(Width, '*');

        var words = input.Split(' ');
        var length = 0;
        var list = new List<string>();
        var res = new List<string>();


        foreach (var word in words)
        {
            if (word.Length > Width - 2 * (PADDING + 1)) throw new Exception("太长了, 装不下了.");
            length += word.Length + 1;
            if (length > Width - 2 * (PADDING + 1))
            {
                var line = string.Join(' ', list);
                res.Add(GetCsLeft(line));
                list.Clear();
            }
            list.Add(word);
        }
        var last = string.Join(' ', list);
        res.Add(GetCsLeft(last));

        return string.Join('\n', res);
    }
    private string GetPyLeft(string input)
    {
        if (input.Length < Width - 2 * (PADDING + 1))
            return input
                .PadLeft(input.Length + 1)
                .PadRight(Width - 2)
                .PadLeft(Width - 1, '#')
                .PadRight(Width, '#');

        var words = input.Split(' ');
        var length = 0;
        var list = new List<string>();
        var res = new List<string>();


        foreach (var word in words)
        {
            if (word.Length > Width - 2 * (PADDING + 1)) throw new Exception("太长了, 装不下了.");
            length += word.Length + 1;
            if (length > Width - 2 * (PADDING + 1))
            {
                var line = string.Join(' ', list);
                res.Add(GetPyLeft(line));
                list.Clear();
            }
            list.Add(word);
        }
        var last = string.Join(' ', list);
        res.Add(GetPyLeft(last));

        return string.Join('\n', res);
    }
    private string GetCsMiddled(string input)
    {
        if (input.Length < Width - 2 * (PADDING + 1))
            return input
                .PadLeft(input.Length / 2 + Width / 2 - 1)
                .PadRight(Width - 2)
                .PadLeft(Width - 1, '*')
                .PadRight(Width, '*');

        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var length = 0;
        var list = new List<string>();
        var res = new List<string>();

        foreach (var word in words)
        {
            if (word.Length > Width - 2 * (PADDING + 1)) throw new Exception("太长了, 装不下了.");
            length += word.Length + 1;
            if (length > Width - 2 * (PADDING + 1))
            {
                var line = string.Join(' ', list);
                res.Add(GetCsMiddled(line));
                list.Clear();
                length = word.Length + 1;
            }
            list.Add(word);
        }
        var last = string.Join(' ', list);
        res.Add(GetCsMiddled(last));

        return string.Join('\n', res);
    }



    private string GetPyMiddled(string input)
    {
        if (input.Length < Width - 2 * (PADDING + 1))
            return input
                .PadLeft(input.Length / 2 + Width / 2 - 1)
                .PadRight(Width - 2)
                .PadLeft(Width - 1, '#')
                .PadRight(Width, '#');

        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var length = 0;
        var list = new List<string>();
        var res = new List<string>();

        foreach (var word in words)
        {
            if (word.Length > Width - 2 * (PADDING + 1)) throw new Exception("太长了, 装不下了.");
            length += word.Length + 1;
            if (length > Width - 2 * (PADDING + 1))
            {
                var line = string.Join(' ', list);
                res.Add(GetPyMiddled(line));
                list.Clear();
                length = word.Length + 1;
            }
            list.Add(word);
        }
        var last = string.Join(' ', list);
        res.Add(GetPyMiddled(last));

        return string.Join('\n', res);
    }

    private string GetCsEmptyLine()
    {
        var arr = new char[Width];
        Array.Fill(arr, ' ');
        arr[0] = arr[^1] = '*';
        return new string(arr);
    }

    private string GetPyEmptyLine()
    {
        var arr = new char[Width];
        Array.Fill(arr, ' ');
        arr[0] = arr[^1] = '#';
        return new string(arr);
    }
}