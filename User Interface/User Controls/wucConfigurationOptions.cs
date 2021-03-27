using System.Windows.Controls;

using VNCCA = VNC.CodeAnalysis;

namespace VNCCodeCommandConsole.User_Interface.User_Controls
{
    /// <summary>
    /// Interaction logic for wucOutputOptions.xaml
    /// </summary>
    public partial class wucConfigurationOptions : UserControl
    {
        public wucConfigurationOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate DisplayInfo with values from the UI
        /// </summary>
        /// <returns></returns>
        public VNC.CodeAnalysis.CodeAnalysisOptions GetConfigurationInfo()
        {
            VNC.CodeAnalysis.CodeAnalysisOptions configurationOptions = new VNCCA.CodeAnalysisOptions();

            var foo = lbeSyntaxWalkerDepth.EditValue;
            var bar = lbeAdditionalNodes.EditValue;
            
            switch (lbeSyntaxWalkerDepth.EditValue)
            {
                case "Node":
                    configurationOptions.SyntaxWalkerDepth = Microsoft.CodeAnalysis.SyntaxWalkerDepth.Node;
                    break;

                case "Token":
                    configurationOptions.SyntaxWalkerDepth = Microsoft.CodeAnalysis.SyntaxWalkerDepth.Token;
                    break;

                case "Trivia":
                    configurationOptions.SyntaxWalkerDepth = Microsoft.CodeAnalysis.SyntaxWalkerDepth.Trivia;
                    break;

                case "StructureTrivia":
                    configurationOptions.SyntaxWalkerDepth = Microsoft.CodeAnalysis.SyntaxWalkerDepth.StructuredTrivia;
                    break;
            }

            configurationOptions.AdditionalNodeAnalysis = (VNCCA.SyntaxNode.AdditionalNodes)lbeAdditionalNodes.EditValue;

            configurationOptions.DisplayNodeKind = (bool)ceDisplay_NodeKind.IsChecked;
            configurationOptions.DisplayNodeValue = (bool)ceDisplay_NodeValue.IsChecked;
            //configurationOptions.DisplayFormattedOutput = (bool)ceDisplay_FormattedOutput.IsChecked;

            configurationOptions.DisplayNodeParent = (bool)ceDisplay_NodeParent.IsChecked;

            configurationOptions.DisplayStatementBlock = (bool)ceDisplay_StatementBlock.IsChecked;
            configurationOptions.IncludeStatementBlockInCRC = (bool)ceIncludeStatementBlockInCRC.IsChecked;

            configurationOptions.DisplaySourceLocation = (bool)ceDisplaySourceLocation.IsChecked;
            configurationOptions.DisplayCRC32 = (bool)ceDisplayCRC32.IsChecked;
            configurationOptions.ReplaceCRLFInNodeName = (bool)ceReplaceCRLF.IsChecked;

            configurationOptions.DisplayClassOrModuleName = (bool)ceDisplayClassOrModuleName.IsChecked;
            configurationOptions.DisplayMethodName = (bool)ceDisplayMethodName.IsChecked;

            configurationOptions.DisplayContainingMethodBlock = (bool)ceDisplayContainingMethodBlock.IsChecked;
            configurationOptions.DisplayContainingBlock = (bool)ceDisplayContainingBlock.IsChecked;

            configurationOptions.InTryBlock = (bool)ceInTryBlock.IsChecked;
            configurationOptions.InWhileBlock = (bool)ceInWhileBlock.IsChecked;
            configurationOptions.InForBlock = (bool)ceInForBlock.IsChecked;
            configurationOptions.InIfBlock = (bool)ceInIfBlock.IsChecked;

            configurationOptions.AllTypes = (bool)ceAllTypes.IsChecked;

            configurationOptions.Byte = (bool)ceIsByte.IsChecked;
            configurationOptions.Boolean = (bool)ceIsBoolean.IsChecked;
            configurationOptions.Date = (bool)ceIsDate.IsChecked;
            configurationOptions.DataTable = (bool)ceIsDataTable.IsChecked;
            configurationOptions.DateTime = (bool)ceIsDateTime.IsChecked;
            configurationOptions.Int16 = (bool)ceIsInt16.IsChecked;
            configurationOptions.Int32 = (bool)ceIsInt32.IsChecked;
            configurationOptions.Integer = (bool)ceIsInteger.IsChecked;
            configurationOptions.Long = (bool)ceIsLong.IsChecked;
            configurationOptions.Single = (bool)ceIsSingle.IsChecked;
            configurationOptions.String = (bool)ceIsString.IsChecked;

            configurationOptions.OtherTypes = (bool)ceOtherTypes.IsChecked;

            configurationOptions.AddFileSuffix = (bool)ceAddFileSuffix.IsChecked;
            configurationOptions.FileSuffix = teFileSuffix.Text;

            return configurationOptions;
        }
    }
}
