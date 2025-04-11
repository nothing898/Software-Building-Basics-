using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using homework1;

namespace OrderWinFormApp
{
    public partial class OrderEditForm : Form
    {
        public Order Order { get; private set; }
        private List<OrderDetails> detailsList = new List<OrderDetails>();
        private bool isEditMode = false;

        public OrderEditForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Text = "添加订单";
        }

        // 修改订单模式的构造函数
        public OrderEditForm(Order order) : this()
        {
            if (order != null)
            {
                isEditMode = true;
                this.Text = "修改订单";
                Order = order;
                txtOrderId.Text = order.OrderId.ToString();
                txtOrderId.Enabled = false; // 修改模式下订单号不允许修改
                txtCustomer.Text = order.Customer;
                detailsList = order.OrderDetailsList.ToList();
                RefreshDetailsListBox();
            }
        }

        private TextBox txtOrderId, txtCustomer, txtProductName, txtQuantity, txtUnitPrice;
        private ListBox lstDetails;
        private Button btnAddDetail, btnRemoveDetail, btnSave, btnCancel;

        private void InitializeCustomComponents()
        {
            this.Width = 500;
            this.Height = 500;

            Label lblOrderId = new Label() { Text = "订单号：", Left = 20, Top = 20, Width = 80 };
            this.Controls.Add(lblOrderId);
            txtOrderId = new TextBox() { Left = 100, Top = 20, Width = 100 };
            this.Controls.Add(txtOrderId);

            Label lblCustomer = new Label() { Text = "客户：", Left = 220, Top = 20, Width = 80 };
            this.Controls.Add(lblCustomer);
            txtCustomer = new TextBox() { Left = 280, Top = 20, Width = 150 };
            this.Controls.Add(txtCustomer);

            // 订单明细部分
            GroupBox groupDetails = new GroupBox() { Text = "订单明细", Left = 20, Top = 60, Width = 420, Height = 250 };
            this.Controls.Add(groupDetails);

            Label lblProductName = new Label() { Text = "商品名称：", Left = 10, Top = 30, Width = 80 };
            groupDetails.Controls.Add(lblProductName);
            txtProductName = new TextBox() { Left = 100, Top = 30, Width = 100 };
            groupDetails.Controls.Add(txtProductName);

            Label lblQuantity = new Label() { Text = "数量：", Left = 220, Top = 30, Width = 50 };
            groupDetails.Controls.Add(lblQuantity);
            txtQuantity = new TextBox() { Left = 270, Top = 30, Width = 50 };
            groupDetails.Controls.Add(txtQuantity);

            Label lblUnitPrice = new Label() { Text = "单价：", Left = 340, Top = 30, Width = 50 };
            groupDetails.Controls.Add(lblUnitPrice);
            txtUnitPrice = new TextBox() { Left = 390, Top = 30, Width = 50 };
            groupDetails.Controls.Add(txtUnitPrice);

            btnAddDetail = new Button() { Text = "添加明细", Left = 10, Top = 70, Width = 80 };
            btnAddDetail.Click += BtnAddDetail_Click;
            groupDetails.Controls.Add(btnAddDetail);

            btnRemoveDetail = new Button() { Text = "删除明细", Left = 100, Top = 70, Width = 80 };
            btnRemoveDetail.Click += BtnRemoveDetail_Click;
            groupDetails.Controls.Add(btnRemoveDetail);

            lstDetails = new ListBox() { Left = 10, Top = 110, Width = 420, Height = 120 };
            groupDetails.Controls.Add(lstDetails);

            btnSave = new Button() { Text = "保存", Left = 100, Top = 330, Width = 100 };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button() { Text = "取消", Left = 220, Top = 330, Width = 100 };
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        private void BtnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show("请填写完整的订单明细信息！");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("数量输入错误！");
                return;
            }

            if (!double.TryParse(txtUnitPrice.Text, out double unitPrice))
            {
                MessageBox.Show("单价输入错误！");
                return;
            }

            OrderDetails detail = new OrderDetails(txtProductName.Text.Trim(), quantity, unitPrice);
            try
            {
                if (detailsList.Contains(detail))
                {
                    MessageBox.Show("该订单明细已存在！");
                    return;
                }
                detailsList.Add(detail);
                RefreshDetailsListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItem != null)
            {
                OrderDetails selectedDetail = lstDetails.SelectedItem as OrderDetails;
                detailsList.Remove(selectedDetail);
                RefreshDetailsListBox();
            }
        }

        private void RefreshDetailsListBox()
        {
            lstDetails.DataSource = null;
            lstDetails.DataSource = detailsList;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text) ||
                string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                MessageBox.Show("请填写订单号和客户名称！");
                return;
            }

            if (!int.TryParse(txtOrderId.Text, out int orderId))
            {
                MessageBox.Show("订单号输入错误！");
                return;
            }

            if (detailsList.Count == 0)
            {
                MessageBox.Show("订单必须包含至少一项明细！");
                return;
            }

            if (!isEditMode)
            {
                Order = new Order(orderId, txtCustomer.Text.Trim());
            }
            else
            {
                Order.Customer = txtCustomer.Text.Trim();
                Order.OrderDetailsList.Clear();
            }

            foreach (var detail in detailsList)
            {
                try
                {
                    Order.AddOrderDetails(detail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加订单明细时出错：" + ex.Message);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
