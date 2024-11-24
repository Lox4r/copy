using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());
            if (visibleWords.Count == 0) break;

            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public bool IsFullyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.ConvertAll(word => word.GetDisplayText()));
        return $"{_reference.GetReference()}:\n{scriptureText}";
    }
}
