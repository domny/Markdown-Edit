﻿using System.Windows.Input;
using MarkdownEdit.Commands;
using MarkdownEdit.Models;

namespace MarkdownEdit.Controls
{
    public partial class GotoLineDialog
    {
        public static RoutedCommand AcceptLineNumberCommand = new RoutedUICommand();

        public GotoLineDialog()
        {
            InitializeComponent();
            Line.Focus();
            CommandBindings.Add(new CommandBinding(AcceptLineNumberCommand, ExecuteAcceptLineNumber));
        }

        private void ExecuteAcceptLineNumber(object sender, ExecutedRoutedEventArgs e)
        {
            int number;
            if (int.TryParse(Line.Text, out number))
            {
                ScrollToLineCommand.Command.Execute(number, Owner);
                Close();
            }
            else
            {
                Notify.Beep();
            }
        }

        private void ExecuteClose(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            Close();
        }
    }
}