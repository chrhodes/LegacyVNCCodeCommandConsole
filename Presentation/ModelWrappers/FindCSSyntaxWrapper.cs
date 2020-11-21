using System.Collections.Generic;

using VNC.Core.Mvvm;

using VNCCodeCommandConsole.Domain;

namespace VNCCodeCommandConsole.Presentation.ModelWrappers
{
    public class FindCSSyntaxWrapper : ModelWrapper<Domain.FindCSSyntax>
    {
        public FindCSSyntaxWrapper() { }
        public FindCSSyntaxWrapper(Domain.FindCSSyntax model) : base(model)
        {
        }

        // TODO(crhodes)
        // Wrap each property from the passed in model.

        public string StringProperty { get { return GetValue<string>(); } set { SetValue(value); } }
        public int IntProperty { get { return GetValue<int>(); } set { SetValue(value); } }
    }
}
