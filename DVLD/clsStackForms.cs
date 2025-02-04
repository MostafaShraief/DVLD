using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsStackForms
    {

        private Stack<Form> _stkBackwardForms = new Stack<Form>(); // this stack will hold the current opened form and all previous forms.
        private Stack<Form> _stkForwardForms = new Stack<Form>(); // this stack will hold only fomrs that come next of current form.

        public int FormsBackwardCount
        { 
            get
            {
                return _stkBackwardForms.Count;
            }
        }

        public int FormsForwardCount
        {
            get
            {
                return _stkForwardForms.Count;
            }
        }

        private void _LoadForm(Form form, Panel panel)
        {
            if (panel.Controls.Count > 0)
                panel.Controls.Clear();

            panel.Enabled = true;
            if (form != null)
            {
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                panel.Controls.Add(form);
                form.Focus();
                form.Show();
            }
        }

        private void _ResetForwardStack()
        {
            while (_stkForwardForms.Count > 0) 
            {
                // Clear all forms from stkForwardForms and memory.
                _stkForwardForms.First().Dispose();
                _stkForwardForms.Pop();
            }
        }

        public bool PushNewForm(Form frm, Panel pnl) 
        {
            // push form to backward stack and clear all forms in forward stack.
            if (frm == null)
                return false;

            if (_stkBackwardForms.Count > 0 && frm.Tag == _stkBackwardForms.First().Tag)
                return false;

            _stkBackwardForms.Push(frm);

            _ResetForwardStack();

            _LoadForm(_stkBackwardForms.First(), pnl);

            return true;
        }

        public bool PopForm(Panel pnl)
        {
            // pop form from backward stack and push it to forward stack.
            int count = _stkBackwardForms.Count;

            if (count == 0)
                return false;

            _stkForwardForms.Push(_stkBackwardForms.First());
            _stkBackwardForms.Pop();
            --count;

            if (count > 0)
                _LoadForm(_stkBackwardForms.First(), pnl);

            return true;
        }

        public bool RestoreForm_Forwarding(Panel pnl)
        {
            // push form to backward stack from forward stack and pop it from forward stack.
            if (_stkForwardForms.Count == 0)
                return false;

            _stkBackwardForms.Push(_stkForwardForms.First());

            _LoadForm(_stkBackwardForms.First(), pnl);

            _stkForwardForms.Pop();

            return true;
        }
    }
}
