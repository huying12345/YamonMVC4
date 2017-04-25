  --‘ˆº” «∑ÒÕÀµ•…Û∫À
alter table  [Product_OrderRefund] add Status int;

GO

/****** Object:  Table [dbo].[Product_Discount]    Script Date: 2017-01-06 09:48:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountName] [nvarchar](100) NOT NULL,
	[IsDefault] [int] NOT NULL,
	[DiscountPercent] [numeric](4, 2) NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_Product_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Product_Discount] ADD  CONSTRAINT [DF__Product_D__IsDef__3587F3E0]  DEFAULT ((0)) FOR [IsDefault]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’€ø€±‡∫≈' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Discount', @level2type=N'COLUMN',@level2name=N'DiscountID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’€ø€√˚≥∆' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Discount', @level2type=N'COLUMN',@level2name=N'DiscountName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' «∑Òƒ¨»œ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Discount', @level2type=N'COLUMN',@level2name=N'IsDefault'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’€ø€¬ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Discount', @level2type=N'COLUMN',@level2name=N'DiscountPercent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'≈≈–Ú∫≈' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Discount', @level2type=N'COLUMN',@level2name=N'OrderID'
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[View_OrderRefund]
AS
SELECT   b.RefundID, a.OrderDetailID, a.OrderID, a.ProductID, a.ProductNo, a.Price, a.Num, a.SalePrice, a.Comment, 
                a.ProductName, a.TypeName, a.Models, a.TotalMoney, a.MemberID, a.CreateUserID, a.Status AS OrderStatus, 
                a.PayStatus, a.PayType, a.DetailStatus, b.RefundMoney, b.RefundTime, b.RefundUserID, b.Status, a.CreateTime
FROM      dbo.View_Product_OrderDetail AS a INNER JOIN
                dbo.Product_OrderRefund AS b ON a.OrderDetailID = b.OrderDetailID

GO


