using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace NDPSo.Utils
{
    public class TramTromMessageBox
    {
        public static void ShowDEPErrorDialog(System.Exception ex)
        {
            int num = (int)new FrmErrorMessage(ex, false)
            {
                AlertMessage = "System Error!\nPlease contact administrator for more detail."
            }.ShowDialog();
        }

        public static void ShowDEPErrorDialog(string errorMsg)
        {
            int num = (int)new FrmErrorMessage(errorMsg, false)
            {
                AlertMessage = "System Error!\nPlease contact administrator for more detail."
            }.ShowDialog();
        }

        public static void ShowDEPErrorDialog(System.Exception ex, string message)
        {
            int num = (int)new FrmErrorMessage(ex, false)
            {
                AlertMessage = message
            }.ShowDialog();
        }

        public static void ShowErrorDialog(string message, Control focusControl)
        {
            int num = (int)XtraMessageBox.Show(message, "Require Input", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            focusControl.Focus();
        }

        public static void ShowErrorDialog(string message)
        {
            int num = (int)XtraMessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void ShowMessageDialog(string message)
        {
            int num = (int)XtraMessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void ShowWarningDialog(string message)
        {
            int num = (int)XtraMessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowYesNoDialog(string confirmMsg) => XtraMessageBox.Show(confirmMsg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        public static DialogResult ShowYesNoCancelDialog(string confirmMsg) => XtraMessageBox.Show(confirmMsg, "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }
}
