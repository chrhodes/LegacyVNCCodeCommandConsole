using System;
using System.Text;
using System.Windows;
using DevExpress.Xpf.Editors;

using VNC;
using VNC.CodeAnalysis;

using VNCCA = VNC.CodeAnalysis;
using VNCSW = VNC.CodeAnalysis.SyntaxWalkers;

namespace VNCCodeCommandConsole.User_Interface.User_Controls
{
    public partial class wucCommandsFindVBSyntax : wucDXBase
    {
        #region Enums, Fields, Properties
        private static int CLASS_BASE_ERRORNUMBER = ErrorNumbers.APPERROR;
        private const string LOG_APPNAME = Common.LOG_APPNAME;

        #endregion

        #region Constructors

        public wucCommandsFindVBSyntax()
        {
            //#if TRACE
            long startTicks = Log.Trace15("Enter", LOG_APPNAME);
            //#endif
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.InnerException.ToString());
            }
            //#if TRACE
            Log.Trace15("End", LOG_APPNAME, startTicks);
            //#endif
        }

        #endregion

        #region Internal Methods

        #endregion

        #region Initialization and Load

        internal override void OnLoaded(object sender, RoutedEventArgs e)
        {
            //#if TRACE
            long startTicks = Log.Trace15("Enter", LOG_APPNAME);
            //#endif
            // Cheat and force outcome if not using dat
            Common.DataFullyLoaded = true;
            User_Interface.Helper.ValidateDataFullyLoaded();
            LoadControlContents();

            try
            {
                if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                {
                    //dataGrid.ItemsSource = VNCWPFUserControls.Common.ApplicationDataSet.ApplicationUsage;
                }

                //ViewMode.ApplyAuthorization(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //#if TRACE
            Log.Trace15("End", LOG_APPNAME, startTicks);
            //#endif
        }

        #endregion

        #region Event Handlers
        private void ceShowClassBlock_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            var isChecked = (Boolean)((CheckEdit)sender).IsChecked.Value;
            // TODO(crhodes)
            // What would be cool is to look for the parent that is a TextBlock.
            // For now be boring and give it a name.
            teWalk_ClassStatement.Text = isChecked ? "ClassBlock Walker" : "ClassStatement Walker";

        }
        private void ceShowMethodBlock_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            var isChecked = (Boolean)((CheckEdit)sender).IsChecked.Value;
            // TODO(crhodes)
            // What would be cool is to look for the parent that is a TextBlock.
            // For now be boring and give it a name.
            teWalk_MethodStatement.Text = isChecked ? "MethodBlock Walker" : "MethodStatement Walker";
        }

        private void btnHandlesClauseWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayHandlesClauseVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnMultiLineLambdaExpressionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayMultiLineLambdaExpressionVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnSingleLineLambdaExpressionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplaySingleLineLambdaExpressionVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnStopOrEndStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayStopOrEndStatementVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnExpressionStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayExpressionStatementVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnAsNewClauseWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayAsNewClauseVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnFindStructures_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayStructureBlockWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnFieldDeclarationWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayFieldDeclarationWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnClassStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayClassStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnBinaryExpresionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayBinaryExpressiontWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnAssignmentStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayAssignmentStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnArgumentListWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayArgumentListWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnImportsStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayImportsStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnInvocationExpressionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayInvocationExpressionWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnLocalDeclarationStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayLocalDeclarationStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnMemberAccessExpressionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayMemberAccessExpressionWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnMethodBlockWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayMethodBlockWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnMethodStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayMethodStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnModuleStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayModuleStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnNamespaceStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayNamespaceStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnObjectCreationExpressionWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayObjectCreationExpressionWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnParameterListWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayParameterListWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnPropertyStatementWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayPropertyStatementWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnSimpleAsClauseWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplaySimpleAsClauseWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnSyntaxNodeWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplaySyntaxNodeWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnSyntaxTokenWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplaySyntaxTokenWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnSyntaxTriviaWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplaySyntaxTriviaWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        private void btnVariableDeclaratorWalker_Click(object sender, RoutedEventArgs e)
        {
            Helper.ProcessOperation(DisplayVariableDeclaratorWalkerVB, CodeExplorer, CodeExplorerContext, CodeExplorer.configurationOptions);
        }

        #endregion

        #region Private Methods


        #endregion

        #region Main Function Routines

        StringBuilder DisplayStopOrEndStatementVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.StopOrEndStatement();

            //commandConfiguration.WalkerPattern.UseRegEx = (bool)ceExpressionStatementUseRegEx.IsChecked;
            //commandConfiguration.WalkerPattern.RegEx = teExpressionStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayExpressionStatementVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.ExpressionStatement();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceExpressionStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teExpressionStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayHandlesClauseVB(SearchTreeCommandConfiguration commandConfiguration)
        {

            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);
            var walker = new VNCSW.VB.HandlesClause();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceHandlesClauseUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teHandlesClauseRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayMultiLineLambdaExpressionVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.MultiLineLambdaExpression();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceMultiLineLambdaExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teMultiLineLambdaExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplaySingleLineLambdaExpressionVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.SingleLineLambdaExpression();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceSingleLineLambdaExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teSingleLineLambdaExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayMemberAccessExpressionWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.MemberAccessExpression();

            // TODO(crhodes)
            // Leaving this comment in to show the progression from too many arguments to commandConfiguration class.
            // Adding another argument was a pain.  Had to change too many places.  Adding another thing is now easy.

            //return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(sb,
            //    (bool)ceMemberAccessExpressionUseRegEx.IsChecked, teMemberAccessExpressionRegEx.Text,
            //    matches, crcMatchesToString, crcMatchesToFullString, tree, walker, CodeExplorer.configurationOptions.GetConfigurationInfo());

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceMemberAccessExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teMemberAccessExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplaySyntaxNodeWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.SyntaxNode();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceSyntaxNodeUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teSyntaxNodeRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplaySyntaxTokenWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.SyntaxToken();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceSyntaxTokenUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teSyntaxTokenRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayAsNewClauseVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.AsNewClause();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceAsNewClauseUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teAsNewClauseRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplaySimpleAsClauseWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {

            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);
            var walker = new VNCSW.VB.SimpleAsClause();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceSimpleAsClauseUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teSimpleAsClauseRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayObjectCreationExpressionWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.ObjectCreationExpression();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceObjectCreationExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teObjectCreationExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplaySyntaxTriviaWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.SyntaxTrivia();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceSyntaxTriviaUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teSyntaxTriviaRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayBinaryExpressiontWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.BinaryExpression();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceBinaryExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teBinaryExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }
        StringBuilder DisplayAssignmentStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.AssignmentStatement();
            walker.MatchLeft = (bool)ceAssignmentStatementMatchLeft.IsChecked;
            walker.MatchRight = (bool)ceAssignmentStatementMatchRight.IsChecked;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceAssignmentStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teAssignmentStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayLocalDeclarationStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.LocalDeclarationStatement();

            walker.HasAttributes = (bool)CodeExplorer.configurationOptions.ceHasAttributes.IsChecked;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceLocalDeclarationStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teLocalDeclarationStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayStructureBlockWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.StructureBlock();

            walker.ShowFields = (bool)ceStructureShowFields.IsChecked;

            walker.HasAttributes = (bool)CodeExplorer.configurationOptions.ceHasAttributes.IsChecked;

            walker.AllFieldTypes = (bool)CodeExplorer.configurationOptions.ceAllTypes.IsChecked;
            walker.FieldNames = (bool)ceStructureFieldsUseRegEx.IsChecked ? teStructureFieldsRegEx.Text : ".*";
            walker.StructureNames = (bool)ceStructuresUseRegEx.IsChecked ? teStructureRegEx.Text : ".*";

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceStructuresUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teStructureRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            // StructureBlock has special (two types) of RegEx.
            walker.InitializeRegEx();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayVariableDeclaratorWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.VariableDeclarator();

            walker.HasAttributes = (bool)CodeExplorer.configurationOptions.ceHasAttributes.IsChecked;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceVariableDeclaratorUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teVariableDeclaratorRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayInvocationExpressionWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.InvocationExpression();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceInvocationExpressionUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teInvocationExpressionRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayParameterListWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.ParameterList();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceParameterListUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teParameterListRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayArgumentListWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.ArgumentList();

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceArgumentListUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teArgumentListRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayPropertyStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCSW.VB.VNCVBTypedSyntaxWalkerBase walker = null;

            if ((bool)ceShowPropertyBlock.IsChecked)
            {
                walker = new VNCSW.VB.PropertyBlock();
            }
            else
            {
                walker = new VNCSW.VB.PropertyStatement();
            }

            walker.HasAttributes = (bool)CodeExplorer.configurationOptions.ceHasAttributes.IsChecked;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)cePropertyStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = tePropertyStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayFieldDeclarationWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCCA.SyntaxNode.FieldDeclarationLocation fieldDeclarationLocation = VNCCA.SyntaxNode.FieldDeclarationLocation.Class;

            // TODO(crhodes)
            // Go look at EyeOnLife and see how to do this in a cleaner way.

            switch (lbeFieldDeclarationLocation.EditValue.ToString())
            {
                case "Class":
                    fieldDeclarationLocation = VNCCA.SyntaxNode.FieldDeclarationLocation.Class;
                    break;

                case "Module":
                    fieldDeclarationLocation = VNCCA.SyntaxNode.FieldDeclarationLocation.Module;
                    break;

                case "Structure":
                    fieldDeclarationLocation = VNCCA.SyntaxNode.FieldDeclarationLocation.Structure;
                    break;
            }
            VNCSW.VB.VNCVBTypedSyntaxWalkerBase walker = null;

            walker = new VNCSW.VB.FieldDeclaration(fieldDeclarationLocation);

            walker.HasAttributes = (bool)CodeExplorer.configurationOptions.ceHasAttributes.IsChecked;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceFieldDeclarationUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teFieldDeclarationRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayClassStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCSW.VB.VNCVBSyntaxWalkerBase walker = null;

            if ((bool)ceShowClassBlock.IsChecked)
            {
                walker = new VNCSW.VB.ClassBlock();
            }
            else
            {
                walker = new VNCSW.VB.ClassStatement();
            }

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceClassStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teClassStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        private StringBuilder DisplayImportsStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.ImportsStatement();

            //return VNCCA.Helpers.VB.InvokeVNCSyntaxWalkerOld(commandConfiguration.Results,
            //    (bool)ceImportsStatementUseRegEx.IsChecked, teImportsStatementRegEx.Text,
            //    commandConfiguration.Matches, 
            //    commandConfiguration.CRCMatchesToString, 
            //    commandConfiguration.CRCMatchesToFullString,
            //    commandConfiguration.SyntaxTree, 
            //    walker, 
            //    CodeExplorer.configurationOptions.GetConfigurationInfo());

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceImportsStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teImportsStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);
        }

        StringBuilder DisplayMethodBlockWalkerVB(SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCSW.VB.VNCVBTypedSyntaxWalkerBase walker = null;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceMethodBlockUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teMethodBlockRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            // TODO(crhodes)
            // Maybe figure out how to suppress showing of block.

            //if ((bool)ceShowMethodBlock2.IsChecked)
            //{
            walker = new VNCSW.VB.MethodBlock();
            //commandConfiguration.CodeAnalysisOptions.ShowAnalysisCRC = true;
            //}
            //else
            //{
            //    walker = new VNCSW.VB.MethodStatement();
            //}

            StringBuilder results = VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);

            // We may have done a deep dive on a method.  Go grab the results.
            // TODO(crhodes)
            // This might only be if in MethodBlock mode.  See above.

            CodeExplorer.teSyntaxNode.Text += walker.WalkerNode.ToString();
            CodeExplorer.teSyntaxToken.Text += walker.WalkerToken.ToString();
            CodeExplorer.teSyntaxTrivia.Text += walker.WalkerTrivia.ToString();
            CodeExplorer.teSyntaxStructuredTrivia.Text += walker.WalkerStructuredTrivia.ToString();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return results;
        }

        private StringBuilder DisplayMethodStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCSW.VB.VNCVBTypedSyntaxWalkerBase walker = null;

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceMethodStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teMethodStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            if ((bool)ceShowMethodBlock.IsChecked)
            {
                walker = new VNCSW.VB.MethodBlock();
                //commandConfiguration.CodeAnalysisOptions.ShowAnalysisCRC = true;
            }
            else
            {
                walker = new VNCSW.VB.MethodStatement();
            }

            StringBuilder results = VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker, commandConfiguration);

            // We may have done a deep dive on a method.  Go grab the results.
            // TODO(crhodes)
            // This might only be if in MethodBlock mode.  See above.

            CodeExplorer.teSyntaxNode.Text += walker.WalkerNode.ToString();
            CodeExplorer.teSyntaxToken.Text += walker.WalkerToken.ToString();
            CodeExplorer.teSyntaxTrivia.Text += walker.WalkerTrivia.ToString();
            CodeExplorer.teSyntaxStructuredTrivia.Text += walker.WalkerStructuredTrivia.ToString();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return results;
        }

        private StringBuilder DisplayModuleStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            VNCSW.VB.VNCVBTypedSyntaxWalkerBase walker = null;

            if ((bool)ceShowModuleBlock.IsChecked)
            {
                walker = new VNCSW.VB.ModuleBlock();
            }
            else
            {
                walker = new VNCSW.VB.ModuleStatement();
            }


            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceModuleStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teModuleStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker,
                commandConfiguration);

        }

        private StringBuilder DisplayNamespaceStatementWalkerVB(VNCCA.SearchTreeCommandConfiguration commandConfiguration)
        {
            long startTicks = Log.Trace15("Enter", Common.LOG_APPNAME);

            var walker = new VNCSW.VB.NamespaceStatement();

            //return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(sb,
            //    (bool)ceNamespaceStatementUseRegEx.IsChecked, teNamespaceStatementRegEx.Text,
            //    matches, crcMatchesToString, crcMatchesToFullString, tree, walker, CodeExplorer.configurationOptions.GetConfigurationInfo());

            commandConfiguration.WalkerPattern.UseRegEx = (bool)ceNamespaceStatementUseRegEx.IsChecked;
            commandConfiguration.WalkerPattern.RegEx = teNamespaceStatementRegEx.Text;
            commandConfiguration.CodeAnalysisOptions = CodeExplorer.configurationOptions.GetConfigurationInfo();

            Log.Trace15("Exit", Common.LOG_APPNAME, startTicks);

            return VNCCA.Helpers.VB.InvokeVNCSyntaxWalker(walker,
                commandConfiguration);
        }

        #endregion

        #region Utility Methods

        #endregion
    }
}
