public class Comment
{
    // Member variables
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Getters for properties
    public string Name => _name;
    public string Text => _text;
}
