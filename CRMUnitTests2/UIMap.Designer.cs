﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CRMUnitTests2
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// CodedUIAddNewProductForm - Use 'CodedUIAddNewProductFormParams' to pass parameters into this method.
        /// </summary>
        public void CodedUIAddNewProductForm()
        {
            #region Variable Declarations
            WpfEdit uITbUserNameEdit = this.UICRMsystemWindow.UITbUserNameEdit;
            WpfEdit uIPbPswEdit = this.UICRMsystemWindow.UIPbPswEdit;
            WpfButton uIENTERButton = this.UICRMsystemWindow.UIENTERButton;
            WpfButton uIBtNewProductButton = this.UICRMSystemUserValeriyWindow.UIItemToolBar.UIBtNewProductButton;
            WpfEdit uITbAddProductNameEdit = this.UINewProductWindow.UITbAddProductNameEdit;
            WpfEdit uITbAddProductTypeEdit = this.UINewProductWindow.UITbAddProductTypeEdit;
            WpfEdit uITbAddProducerNameEdit = this.UINewProductWindow.UITbAddProducerNameEdit;
            WpfEdit uITbAddProductModelEdit = this.UINewProductWindow.UITbAddProductModelEdit;
            WpfEdit uITbAddProductColorEdit = this.UINewProductWindow.UITbAddProductColorEdit;
            WpfEdit uITbAddProductWeightEdit = this.UINewProductWindow.UITbAddProductWeightEdit;
            WpfEdit uITbAddProductUnitPricEdit = this.UINewProductWindow.UITbAddProductUnitPricEdit;
            WpfEdit uITbAddProductCustomerEdit = this.UINewProductWindow.UITbAddProductCustomerEdit;
            WpfEdit uITbAddProductUnitsInSEdit = this.UINewProductWindow.UITbAddProductUnitsInSEdit;
            WpfRadioButton uIYESRadioButton = this.UINewProductWindow.UIYESRadioButton;
            WpfEdit uITbAddProductDescriptEdit = this.UINewProductWindow.UITbAddProductDescriptEdit;
            WpfButton uIADDButton = this.UINewProductWindow.UIADDButton;
            WinButton uIYesButton = this.UIAddWindow.UIYesWindow.UIYesButton;
            WpfButton uICLOSEButton = this.UINewProductWindow.UICLOSEButton;
            #endregion

            // Type 'pedro' in 'tbUserName' text box
            uITbUserNameEdit.Text = this.CodedUIAddNewProductFormParams.UITbUserNameEditText;

            // Click 'pbPsw' text box
            Mouse.Click(uIPbPswEdit, new Point(39, 7));

            // Type '********' in 'pbPsw' text box
            Keyboard.SendKeys(uIPbPswEdit, this.CodedUIAddNewProductFormParams.UIPbPswEditSendKeys, true);

            // Click 'ENTER' button
            Mouse.Click(uIENTERButton, new Point(24, 16));

            // Click 'btNewProduct' button
            Mouse.Click(uIBtNewProductButton, new Point(26, 28));

            // Type 'Canon54' in 'tbAddProductName' text box
            uITbAddProductNameEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductNameEditText;

            // Type 'printer' in 'tbAddProductType' text box
            uITbAddProductTypeEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductTypeEditText;

            // Type 'Canon Ltd' in 'tbAddProducerName' text box
            uITbAddProducerNameEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProducerNameEditText;

            // Type 'PIXMA-4269' in 'tbAddProductModel' text box
            uITbAddProductModelEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductModelEditText;

            // Type 'red' in 'tbAddProductColor' text box
            uITbAddProductColorEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductColorEditText;

            // Type '5.2' in 'tbAddProductWeight' text box
            uITbAddProductWeightEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductWeightEditText;

            // Type '129.99' in 'tbAddProductUnitPrice' text box
            uITbAddProductUnitPricEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductUnitPricEditText;

            // Type '2' in 'tbAddProductCustomerRating' text box
            uITbAddProductCustomerEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductCustomerEditText;

            // Type '10' in 'tbAddProductUnitsInStock' text box
            uITbAddProductUnitsInSEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductUnitsInSEditText;

            // Select 'YES' radio button
            uIYESRadioButton.Selected = this.CodedUIAddNewProductFormParams.UIYESRadioButtonSelected;

            // Type 'refurbished' in 'tbAddProductDescription' text box
            uITbAddProductDescriptEdit.Text = this.CodedUIAddNewProductFormParams.UITbAddProductDescriptEditText;

            // Click 'ADD' button
            Mouse.Click(uIADDButton, new Point(72, 16));

            // Click '&Yes' button
            Mouse.Click(uIYesButton, new Point(42, 12));

            // Click 'CLOSE' button
            Mouse.Click(uICLOSEButton, new Point(18, 26));
        }
        
        #region Properties
        public virtual CodedUIAddNewProductFormParams CodedUIAddNewProductFormParams
        {
            get
            {
                if ((this.mCodedUIAddNewProductFormParams == null))
                {
                    this.mCodedUIAddNewProductFormParams = new CodedUIAddNewProductFormParams();
                }
                return this.mCodedUIAddNewProductFormParams;
            }
        }
        
        public UICRMsystemWindow UICRMsystemWindow
        {
            get
            {
                if ((this.mUICRMsystemWindow == null))
                {
                    this.mUICRMsystemWindow = new UICRMsystemWindow();
                }
                return this.mUICRMsystemWindow;
            }
        }
        
        public UICRMSystemUserValeriyWindow UICRMSystemUserValeriyWindow
        {
            get
            {
                if ((this.mUICRMSystemUserValeriyWindow == null))
                {
                    this.mUICRMSystemUserValeriyWindow = new UICRMSystemUserValeriyWindow();
                }
                return this.mUICRMSystemUserValeriyWindow;
            }
        }
        
        public UINewProductWindow UINewProductWindow
        {
            get
            {
                if ((this.mUINewProductWindow == null))
                {
                    this.mUINewProductWindow = new UINewProductWindow();
                }
                return this.mUINewProductWindow;
            }
        }
        
        public UIAddWindow UIAddWindow
        {
            get
            {
                if ((this.mUIAddWindow == null))
                {
                    this.mUIAddWindow = new UIAddWindow();
                }
                return this.mUIAddWindow;
            }
        }
        #endregion
        
        #region Fields
        private CodedUIAddNewProductFormParams mCodedUIAddNewProductFormParams;
        
        private UICRMsystemWindow mUICRMsystemWindow;
        
        private UICRMSystemUserValeriyWindow mUICRMSystemUserValeriyWindow;
        
        private UINewProductWindow mUINewProductWindow;
        
        private UIAddWindow mUIAddWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'CodedUIAddNewProductForm'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class CodedUIAddNewProductFormParams
    {
        
        #region Fields
        /// <summary>
        /// Type 'pedro' in 'tbUserName' text box
        /// </summary>
        public string UITbUserNameEditText = "pedro";
        
        /// <summary>
        /// Type '********' in 'pbPsw' text box
        /// </summary>
        public string UIPbPswEditSendKeys = "Z835TI3Zgo9E3U/I+xdySShA44KVGf0SGXxUyHJSKm2tLzFm0nyHAoymC3nfrH+cM24gREbElbs=";
        
        /// <summary>
        /// Type 'Canon54' in 'tbAddProductName' text box
        /// </summary>
        public string UITbAddProductNameEditText = "Canon54";
        
        /// <summary>
        /// Type 'printer' in 'tbAddProductType' text box
        /// </summary>
        public string UITbAddProductTypeEditText = "printer";
        
        /// <summary>
        /// Type 'Canon Ltd' in 'tbAddProducerName' text box
        /// </summary>
        public string UITbAddProducerNameEditText = "Canon Ltd";
        
        /// <summary>
        /// Type 'PIXMA-4269' in 'tbAddProductModel' text box
        /// </summary>
        public string UITbAddProductModelEditText = "PIXMA-4269";
        
        /// <summary>
        /// Type 'red' in 'tbAddProductColor' text box
        /// </summary>
        public string UITbAddProductColorEditText = "red";
        
        /// <summary>
        /// Type '5.2' in 'tbAddProductWeight' text box
        /// </summary>
        public string UITbAddProductWeightEditText = "5.2";
        
        /// <summary>
        /// Type '129.99' in 'tbAddProductUnitPrice' text box
        /// </summary>
        public string UITbAddProductUnitPricEditText = "129.99";
        
        /// <summary>
        /// Type '2' in 'tbAddProductCustomerRating' text box
        /// </summary>
        public string UITbAddProductCustomerEditText = "2";
        
        /// <summary>
        /// Type '10' in 'tbAddProductUnitsInStock' text box
        /// </summary>
        public string UITbAddProductUnitsInSEditText = "10";
        
        /// <summary>
        /// Select 'YES' radio button
        /// </summary>
        public bool UIYESRadioButtonSelected = true;
        
        /// <summary>
        /// Type 'refurbished' in 'tbAddProductDescription' text box
        /// </summary>
        public string UITbAddProductDescriptEditText = "refurbished";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UICRMsystemWindow : WpfWindow
    {
        
        public UICRMsystemWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "CRM system";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("CRM system");
            #endregion
        }
        
        #region Properties
        public WpfEdit UITbUserNameEdit
        {
            get
            {
                if ((this.mUITbUserNameEdit == null))
                {
                    this.mUITbUserNameEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbUserNameEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbUserName";
                    this.mUITbUserNameEdit.WindowTitles.Add("CRM system");
                    #endregion
                }
                return this.mUITbUserNameEdit;
            }
        }
        
        public WpfEdit UIPbPswEdit
        {
            get
            {
                if ((this.mUIPbPswEdit == null))
                {
                    this.mUIPbPswEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUIPbPswEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "pbPsw";
                    this.mUIPbPswEdit.WindowTitles.Add("CRM system");
                    #endregion
                }
                return this.mUIPbPswEdit;
            }
        }
        
        public WpfButton UIENTERButton
        {
            get
            {
                if ((this.mUIENTERButton == null))
                {
                    this.mUIENTERButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIENTERButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "btEnter";
                    this.mUIENTERButton.WindowTitles.Add("CRM system");
                    #endregion
                }
                return this.mUIENTERButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUITbUserNameEdit;
        
        private WpfEdit mUIPbPswEdit;
        
        private WpfButton mUIENTERButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UICRMSystemUserValeriyWindow : WpfWindow
    {
        
        public UICRMSystemUserValeriyWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = " CRM System User: Valeriy Hohin";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add(" CRM System User: Valeriy Hohin");
            #endregion
        }
        
        #region Properties
        public UIItemToolBar UIItemToolBar
        {
            get
            {
                if ((this.mUIItemToolBar == null))
                {
                    this.mUIItemToolBar = new UIItemToolBar(this);
                }
                return this.mUIItemToolBar;
            }
        }
        #endregion
        
        #region Fields
        private UIItemToolBar mUIItemToolBar;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIItemToolBar : WpfToolBar
    {
        
        public UIItemToolBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add(" CRM System User: Valeriy Hohin");
            #endregion
        }
        
        #region Properties
        public WpfButton UIBtNewProductButton
        {
            get
            {
                if ((this.mUIBtNewProductButton == null))
                {
                    this.mUIBtNewProductButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIBtNewProductButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "btNewProduct";
                    this.mUIBtNewProductButton.WindowTitles.Add(" CRM System User: Valeriy Hohin");
                    #endregion
                }
                return this.mUIBtNewProductButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mUIBtNewProductButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UINewProductWindow : WpfWindow
    {
        
        public UINewProductWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "NewProduct";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("NewProduct");
            #endregion
        }
        
        #region Properties
        public WpfEdit UITbAddProductNameEdit
        {
            get
            {
                if ((this.mUITbAddProductNameEdit == null))
                {
                    this.mUITbAddProductNameEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductNameEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductName";
                    this.mUITbAddProductNameEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductNameEdit;
            }
        }
        
        public WpfEdit UITbAddProductTypeEdit
        {
            get
            {
                if ((this.mUITbAddProductTypeEdit == null))
                {
                    this.mUITbAddProductTypeEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductTypeEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductType";
                    this.mUITbAddProductTypeEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductTypeEdit;
            }
        }
        
        public WpfEdit UITbAddProducerNameEdit
        {
            get
            {
                if ((this.mUITbAddProducerNameEdit == null))
                {
                    this.mUITbAddProducerNameEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProducerNameEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProducerName";
                    this.mUITbAddProducerNameEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProducerNameEdit;
            }
        }
        
        public WpfEdit UITbAddProductModelEdit
        {
            get
            {
                if ((this.mUITbAddProductModelEdit == null))
                {
                    this.mUITbAddProductModelEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductModelEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductModel";
                    this.mUITbAddProductModelEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductModelEdit;
            }
        }
        
        public WpfEdit UITbAddProductColorEdit
        {
            get
            {
                if ((this.mUITbAddProductColorEdit == null))
                {
                    this.mUITbAddProductColorEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductColorEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductColor";
                    this.mUITbAddProductColorEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductColorEdit;
            }
        }
        
        public WpfEdit UITbAddProductWeightEdit
        {
            get
            {
                if ((this.mUITbAddProductWeightEdit == null))
                {
                    this.mUITbAddProductWeightEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductWeightEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductWeight";
                    this.mUITbAddProductWeightEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductWeightEdit;
            }
        }
        
        public WpfEdit UITbAddProductUnitPricEdit
        {
            get
            {
                if ((this.mUITbAddProductUnitPricEdit == null))
                {
                    this.mUITbAddProductUnitPricEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductUnitPricEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductUnitPrice";
                    this.mUITbAddProductUnitPricEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductUnitPricEdit;
            }
        }
        
        public WpfEdit UITbAddProductCustomerEdit
        {
            get
            {
                if ((this.mUITbAddProductCustomerEdit == null))
                {
                    this.mUITbAddProductCustomerEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductCustomerEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductCustomerRating";
                    this.mUITbAddProductCustomerEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductCustomerEdit;
            }
        }
        
        public WpfEdit UITbAddProductUnitsInSEdit
        {
            get
            {
                if ((this.mUITbAddProductUnitsInSEdit == null))
                {
                    this.mUITbAddProductUnitsInSEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductUnitsInSEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductUnitsInStock";
                    this.mUITbAddProductUnitsInSEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductUnitsInSEdit;
            }
        }
        
        public WpfRadioButton UIYESRadioButton
        {
            get
            {
                if ((this.mUIYESRadioButton == null))
                {
                    this.mUIYESRadioButton = new WpfRadioButton(this);
                    #region Search Criteria
                    this.mUIYESRadioButton.SearchProperties[WpfRadioButton.PropertyNames.AutomationId] = "rbYesDiscontinued";
                    this.mUIYESRadioButton.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUIYESRadioButton;
            }
        }
        
        public WpfEdit UITbAddProductDescriptEdit
        {
            get
            {
                if ((this.mUITbAddProductDescriptEdit == null))
                {
                    this.mUITbAddProductDescriptEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbAddProductDescriptEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbAddProductDescription";
                    this.mUITbAddProductDescriptEdit.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUITbAddProductDescriptEdit;
            }
        }
        
        public WpfButton UIADDButton
        {
            get
            {
                if ((this.mUIADDButton == null))
                {
                    this.mUIADDButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIADDButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "btAddProduct";
                    this.mUIADDButton.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUIADDButton;
            }
        }
        
        public WpfButton UICLOSEButton
        {
            get
            {
                if ((this.mUICLOSEButton == null))
                {
                    this.mUICLOSEButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUICLOSEButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "btCloseProduct";
                    this.mUICLOSEButton.WindowTitles.Add("NewProduct");
                    #endregion
                }
                return this.mUICLOSEButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUITbAddProductNameEdit;
        
        private WpfEdit mUITbAddProductTypeEdit;
        
        private WpfEdit mUITbAddProducerNameEdit;
        
        private WpfEdit mUITbAddProductModelEdit;
        
        private WpfEdit mUITbAddProductColorEdit;
        
        private WpfEdit mUITbAddProductWeightEdit;
        
        private WpfEdit mUITbAddProductUnitPricEdit;
        
        private WpfEdit mUITbAddProductCustomerEdit;
        
        private WpfEdit mUITbAddProductUnitsInSEdit;
        
        private WpfRadioButton mUIYESRadioButton;
        
        private WpfEdit mUITbAddProductDescriptEdit;
        
        private WpfButton mUIADDButton;
        
        private WpfButton mUICLOSEButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIAddWindow : WinWindow
    {
        
        public UIAddWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Add";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Add");
            #endregion
        }
        
        #region Properties
        public UIYesWindow UIYesWindow
        {
            get
            {
                if ((this.mUIYesWindow == null))
                {
                    this.mUIYesWindow = new UIYesWindow(this);
                }
                return this.mUIYesWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIYesWindow mUIYesWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIYesWindow : WinWindow
    {
        
        public UIYesWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "6";
            this.WindowTitles.Add("Add");
            #endregion
        }
        
        #region Properties
        public WinButton UIYesButton
        {
            get
            {
                if ((this.mUIYesButton == null))
                {
                    this.mUIYesButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIYesButton.SearchProperties[WinButton.PropertyNames.Name] = "Yes";
                    this.mUIYesButton.WindowTitles.Add("Add");
                    #endregion
                }
                return this.mUIYesButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIYesButton;
        #endregion
    }
}
