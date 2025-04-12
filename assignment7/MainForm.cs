using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Homework1;  // 引用包含 OrderService 等类的业务逻辑代码

namespace OrderWinFormApp
{
    public partial class MainForm : Form
    {
        private OrderService orderService = new OrderService();
        private BindingSource bindingSourceOrders = new BindingSource();
        private List<Order> currentOrderList = new List<Order>();
        private int currentPage = 1;
        private int pageSize = 5;
        private int totalPages = 1;

        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            // 为了演示，预先添加一些订单数据
            LoadSampleData();
            RefreshOrderList();
        }

        private void LoadSampleData()
        {
            try
            {
                Order order1 = new Order(1, "张三");
                order1.AddOrderDetails(new OrderDetails("苹果", 10, 2.5));
                order1.AddOrderDetails(new OrderDetails("香蕉", 5, 1.2));
                orderService.AddOrder(order1);

                Order order2 = new Order(2, "李四");
                order2.AddOrderDetails(new OrderDetails("橙子", 8, 3.0));
                orderService.AddOrder(order2);

                Order order3 = new Order(3, "王五");
                order3.AddOrderDetails(new OrderDetails("梨子", 12, 2.0));
                orderService.AddOrder(order3);

                Order order4 = new Order(4, "赵六");
                order4.AddOrderDetails(new OrderDetails("桃子", 6, 4.0));
                orderService.AddOrder(order4);

                Order order5 = new Order(5, "孙七");
                order5.AddOrderDetails(new OrderDetails("草莓", 15, 5.0));
                orderService.AddOrder(order5);

                Order order6 = new Order(6, "周八");
                order6.AddOrderDetails(new OrderDetails("西瓜", 2, 20.0));
                orderService.AddOrder(order6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeCustomComponents()
        {
            // 设置窗体属性
            this.Text = "订单管理系统";
            this.Width = 800;
            this.Height = 600;

            // 创建 DataGridView 用于显示订单
            DataGridView dgvOrders = new DataGridView();
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.Dock = DockStyle.Top;
            dgvOrders.Height = 300;
            this.Controls.Add(dgvOrders);

            // 创建底部 Panel 放置按钮、分页及查询控件
            Panel panel = new Panel();
            panel.Dock = DockStyle.Bottom;
            panel.Height = 250;
            this.Controls.Add(panel);

            // 添加“添加”、“修改”、“删除”、“刷新”按钮
            Button btnAdd = new Button() { Text = "添加订单", Left = 20, Top = 20, Width = 100 };
            btnAdd.Click += BtnAdd_Click;
            panel.Controls.Add(btnAdd);

            Button btnEdit = new Button() { Text = "修改订单", Left = 140, Top = 20, Width = 100 };
            btnEdit.Click += BtnEdit_Click;
            panel.Controls.Add(btnEdit);

            Button btnDelete = new Button() { Text = "删除订单", Left = 260, Top = 20, Width = 100 };
            btnDelete.Click += BtnDelete_Click;
            panel.Controls.Add(btnDelete);

            Button btnRefresh = new Button() { Text = "刷新列表", Left = 380, Top = 20, Width = 100 };
            btnRefresh.Click += BtnRefresh_Click;
            panel.Controls.Add(btnRefresh);

            // 分页按钮：上一页、下一页，并显示页码信息
            Button btnPrev = new Button() { Text = "上一页", Left = 20, Top = 60, Width = 100 };
            btnPrev.Click += BtnPrev_Click;
            panel.Controls.Add(btnPrev);

            Button btnNext = new Button() { Text = "下一页", Left = 140, Top = 60, Width = 100 };
            btnNext.Click += BtnNext_Click;
            panel.Controls.Add(btnNext);

            Label lblPageInfo = new Label() { Name = "lblPageInfo", Left = 260, Top = 65, Width = 200 };
            panel.Controls.Add(lblPageInfo);

            // 查询控件：订单号、客户、商品名称、订单金额（大于）
            Label lblQuery = new Label() { Text = "查询条件：订单号", Left = 20, Top = 110, Width = 80 };
            panel.Controls.Add(lblQuery);
            TextBox txtQueryOrderId = new TextBox() { Name = "txtQueryOrderId", Left = 110, Top = 107, Width = 100 };
            panel.Controls.Add(txtQueryOrderId);

            Label lblQueryCustomer = new Label() { Text = "客户", Left = 220, Top = 110, Width = 40 };
            panel.Controls.Add(lblQueryCustomer);
            TextBox txtQueryCustomer = new TextBox() { Name = "txtQueryCustomer", Left = 270, Top = 107, Width = 100 };
            panel.Controls.Add(txtQueryCustomer);

            Label lblQueryProduct = new Label() { Text = "商品名", Left = 380, Top = 110, Width = 50 };
            panel.Controls.Add(lblQueryProduct);
            TextBox txtQueryProduct = new TextBox() { Name = "txtQueryProduct", Left = 430, Top = 107, Width = 100 };
            panel.Controls.Add(txtQueryProduct);

            Label lblQueryAmount = new Label() { Text = "订单金额大于", Left = 540, Top = 110, Width = 80 };
            panel.Controls.Add(lblQueryAmount);
            TextBox txtQueryAmount = new TextBox() { Name = "txtQueryAmount", Left = 630, Top = 107, Width = 100 };
            panel.Controls.Add(txtQueryAmount);

            Button btnQuery = new Button() { Text = "查询", Left = 20, Top = 150, Width = 100 };
            btnQuery.Click += BtnQuery_Click;
            panel.Controls.Add(btnQuery);

            // 将 DataGridView 与 BindingSource 绑定
            dgvOrders.DataSource = bindingSourceOrders;
        }

        private void RefreshOrderList()
        {
            // 获取所有订单并进行排序
            currentOrderList = orderService.SortOrders();
            // 分页：计算总页数
            totalPages = (currentOrderList.Count + pageSize - 1) / pageSize;
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;
            // 获取当前页数据
            var ordersPage = currentOrderList
                                .Skip((currentPage - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            bindingSourceOrders.DataSource = ordersPage;

            // 更新页码信息显示
            Label lblPageInfo = this.Controls.Find("lblPageInfo", true).FirstOrDefault() as Label;
            if (lblPageInfo != null)
            {
                lblPageInfo.Text = $"当前页 {currentPage}/{totalPages}";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            OrderEditForm editForm = new OrderEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    orderService.AddOrder(editForm.Order);
                    RefreshOrderList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "添加订单失败");
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DataGridView dgvOrders = this.Controls.Find("dgvOrders", true).FirstOrDefault() as DataGridView;
            if (dgvOrders != null && dgvOrders.CurrentRow != null)
            {
                Order selectedOrder = dgvOrders.CurrentRow.DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    OrderEditForm editForm = new OrderEditForm(selectedOrder);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            orderService.UpdateOrder(editForm.Order);
                            RefreshOrderList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "修改订单失败");
                        }
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgvOrders = this.Controls.Find("dgvOrders", true).FirstOrDefault() as DataGridView;
            if (dgvOrders != null && dgvOrders.CurrentRow != null)
            {
                Order selectedOrder = dgvOrders.CurrentRow.DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    var result = MessageBox.Show("确定要删除该订单吗？", "删除确认", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            orderService.DeleteOrder(selectedOrder.OrderId);
                            RefreshOrderList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "删除订单失败");
                        }
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // 清空查询条件后刷新列表
            ClearQueryFields();
            currentPage = 1;
            RefreshOrderList();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                RefreshOrderList();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                RefreshOrderList();
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            // 根据查询控件的输入进行查询，优先判断订单号，其次客户、商品名、订单金额
            TextBox txtOrderId = this.Controls.Find("txtQueryOrderId", true).FirstOrDefault() as TextBox;
            TextBox txtCustomer = this.Controls.Find("txtQueryCustomer", true).FirstOrDefault() as TextBox;
            TextBox txtProduct = this.Controls.Find("txtQueryProduct", true).FirstOrDefault() as TextBox;
            TextBox txtAmount = this.Controls.Find("txtQueryAmount", true).FirstOrDefault() as TextBox;

            List<Order> queryResult = null;
            if (!string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                if (int.TryParse(txtOrderId.Text, out int orderId))
                {
                    queryResult = orderService.QueryByOrderId(orderId);
                }
                else
                {
                    MessageBox.Show("订单号输入错误！");
                    return;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                queryResult = orderService.QueryByCustomer(txtCustomer.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                queryResult = orderService.QueryByProductName(txtProduct.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                if (double.TryParse(txtAmount.Text, out double amount))
                {
                    queryResult = orderService.QueryByTotalAmount(amount);
                }
                else
                {
                    MessageBox.Show("订单金额输入错误！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请填写查询条件！");
                return;
            }

            if (queryResult != null)
            {
                currentOrderList = queryResult;
                currentPage = 1;
                totalPages = (currentOrderList.Count + pageSize - 1) / pageSize;
                if (totalPages == 0) totalPages = 1;
                RefreshOrderList();
            }
        }

        private void ClearQueryFields()
        {
            TextBox txtOrderId = this.Controls.Find("txtQueryOrderId", true).FirstOrDefault() as TextBox;
            TextBox txtCustomer = this.Controls.Find("txtQueryCustomer", true).FirstOrDefault() as TextBox;
            TextBox txtProduct = this.Controls.Find("txtQueryProduct", true).FirstOrDefault() as TextBox;
            TextBox txtAmount = this.Controls.Find("txtQueryAmount", true).FirstOrDefault() as TextBox;
            if (txtOrderId != null) txtOrderId.Text = "";
            if (txtCustomer != null) txtCustomer.Text = "";
            if (txtProduct != null) txtProduct.Text = "";
            if (txtAmount != null) txtAmount.Text = "";
        }
    }
}
