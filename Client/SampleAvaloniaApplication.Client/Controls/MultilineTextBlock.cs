using Avalonia;
using Avalonia.Controls;
using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace SampleAvaloniaApplication.Client.Controls
{
    public class MultilineTextBlock : TextBlock
    {
        public static readonly DirectProperty<MultilineTextBlock, IEnumerable<string>> LinesProperty =
            AvaloniaProperty.RegisterDirect<MultilineTextBlock, IEnumerable<string>>(
                nameof(Lines),
                o => o.Lines,
                (o, v) => o.Lines = v);

        /// <summary>
        /// Gets or sets the multiline text.
        /// </summary>
        [Content]
        public IEnumerable<string> Lines
        {
            get { return Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries); }
            set { Text = string.Join(Environment.NewLine, value.Where(e => !string.IsNullOrEmpty(e)));  }
        }

        public MultilineTextBlock() : base()
        {
            TextWrapping = Avalonia.Media.TextWrapping.Wrap;
        }
    }
}
