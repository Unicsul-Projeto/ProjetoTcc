
USE [ProjetoTCC]
GO
/****** Object:  Table [dbo].[Uf]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uf](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CEP] [nvarchar](255) NULL,
	[Logradouro] [nvarchar](255) NULL,
	[Bairro] [nvarchar](255) NULL,
	[Cidade] [nvarchar](255) NULL,
	[uf_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PessoaFisica]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PessoaFisica](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
	[CPF] [nvarchar](255) NULL,
	[RG] [nvarchar](255) NULL,
	[Endereco_Id] [int] NULL,
	[NumeroEndereco] [nvarchar](255) NULL,
	[Sexo_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setor]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setor](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[ID] [int] NOT NULL,
	[SetorID] [int] NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[ID] [int] NOT NULL,
	[PessoaFisicaID] [int] NULL,
	[CargoID] [int] NULL,
	[NumCarteira] [nvarchar](255) NULL,
	[DataAdmissao] [datetime] NULL,
	[DataDemissao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lancamento]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lancamento](
	[ID] [int] NOT NULL,
	[Desconto] [nvarchar](255) NULL,
	[Tipo] [nchar](1) NULL,
	[TipoDocumentoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoOperacao]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoOperacao](
	[ID] [int] NOT NULL,
	[Descricao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PessoaJuridica]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PessoaJuridica](
	[ID] [int] NOT NULL,
	[RazaoSocial] [nvarchar](255) NULL,
	[NomeFantasia] [nvarchar](255) NULL,
	[CNPJ] [int] NULL,
	[InscricaoEstadual] [int] NULL,
	[Endereco_Id] [int] NULL,
	[NumeroEndereco] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venda]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venda](
	[ID] [int] NOT NULL,
	[PessoaFisicaID] [int] NULL,
	[PessoaJuridicaID] [int] NULL,
	[FuncionarioID] [int] NULL,
	[Data] [datetime] NULL,
	[Valor] [float] NULL,
	[Desconto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Troca]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Troca](
	[ID] [int] NOT NULL,
	[PessoaFisicaID] [int] NULL,
	[PessoaJuridicaID] [int] NULL,
	[FuncionarioID] [int] NULL,
	[Data] [datetime] NULL,
	[Valor] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[ID] [int] NOT NULL,
	[PessoaJuridicaID] [int] NULL,
	[FuncionarioID] [int] NULL,
	[Data] [datetime] NULL,
	[ValorT] [float] NULL,
	[Desconto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FluxoCaixa]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FluxoCaixa](
	[ID] [int] NOT NULL,
	[VendaID] [int] NULL,
	[CompraID] [int] NULL,
	[TrocaID] [int] NULL,
	[LancamentoID] [int] NULL,
	[TipoOperacaoID] [int] NULL,
	[Valor] [float] NULL,
	[Data] [datetime] NULL,
	[Saldo] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaixaDia]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaixaDia](
	[ID] [int] NOT NULL,
	[FluxoCaixaID] [int] NULL,
	[FuncionarioID] [int] NULL,
	[Data] [datetime] NULL,
	[ValorInicio] [float] NULL,
	[ValorTermino] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caixa]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caixa](
	[ID] [int] NOT NULL,
	[CaixaDiaID] [int] NULL,
	[Data] [int] NULL,
	[SaldoCaixa] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parcelas]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcelas](
	[ID] [int] NOT NULL,
	[FluxoCaixaID] [int] NULL,
	[DataVencto] [datetime] NULL,
	[Valor] [float] NULL,
	[Observacao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentacaoParcelas]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentacaoParcelas](
	[ID] [int] NOT NULL,
	[ParcelaID] [int] NULL,
	[Data] [datetime] NULL,
	[Valor] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormaPagamento]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaPagamento](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
	[QtdeParcelas] [int] NULL,
	[CartaoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prateleira]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prateleira](
	[ID] [int] NOT NULL,
	[Descricao] [int] NULL,
	[QuantidadeLinha] [int] NULL,
	[QuantidadeColuna] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocao]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocao](
	[ID] [int] NOT NULL,
	[DataInicial] [int] NULL,
	[DataFinal] [int] NULL,
	[PercentualDesconto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoUsuario]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoUsuario](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comissao]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comissao](
	[ID] [int] NOT NULL,
	[DataInicial] [datetime] NULL,
	[DataFinal] [datetime] NULL,
	[Percentual] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID] [int] NOT NULL,
	[Descricao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cartao]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartao](
	[ID] [int] NOT NULL,
	[Descricao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Acesso]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acesso](
	[ID] [int] NOT NULL,
	[Descricao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AcessoGrupoUsuario]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcessoGrupoUsuario](
	[ID] [int] NOT NULL,
	[GrupoUsuarioID] [int] NULL,
	[AcessoID] [int] NULL,
	[Descricao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[ID] [int] NOT NULL,
	[PrateleiraID] [int] NULL,
	[Linha] [int] NULL,
	[Coluna] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preco]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preco](
	[ID] [int] NOT NULL,
	[PromocaoID] [int] NULL,
	[Valor] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ID] [int] NOT NULL,
	[CategoriaID] [int] NULL,
	[ComissaoID] [int] NULL,
	[PrecoID] [int] NULL,
	[MarcaID] [int] NULL,
	[Modelo] [nvarchar](255) NULL,
	[ValorCusto] [float] NULL,
	[ValorVenda] [float] NULL,
	[Situacao] [nchar](1) NULL,
	[QuantidadeMinima] [int] NULL,
	[DataCadastro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoEstoque]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoEstoque](
	[MovEstoqueID] [int] NOT NULL,
	[PessoaFisicaID] [int] NULL,
	[PessoaJuridicaID] [int] NULL,
	[TipoOperacaoID] [int] NULL,
	[MovEstoqueData] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MovEstoqueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoEstoqueItem]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoEstoqueItem](
	[ID] [int] NOT NULL,
	[MovEstoqueID] [int] NULL,
	[ProdutoID] [int] NULL,
	[Quantidade] [int] NULL,
	[ValorUnitario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimentacao]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimentacao](
	[ID] [int] NOT NULL,
	[ProdutoID] [int] NULL,
	[VendaID] [int] NULL,
	[CompraID] [int] NULL,
	[TrocaID] [int] NULL,
	[TipoOperacaoID] [int] NULL,
	[ValorDesconto] [float] NULL,
	[ValorProduto] [float] NULL,
	[Quantidade] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LancamentoFinanceiro]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LancamentoFinanceiro](
	[ID] [int] NOT NULL,
	[LancamentoID] [int] NULL,
	[Descricao] [nvarchar](255) NULL,
	[Valor] [float] NULL,
	[Data] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estoque](
	[ID] [int] NOT NULL,
	[ProdutoID] [int] NULL,
	[QuantidadeSaldo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutoGrade]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoGrade](
	[ID] [int] NOT NULL,
	[ProdutoID] [int] NULL,
	[GradeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/21/2012 23:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] NOT NULL,
	[FuncionarioID] [int] NULL,
	[GrupoUsuarioID] [int] NULL,
	[NomeLogin] [nvarchar](255) NULL,
	[Senha] [nvarchar](255) NULL,
	[DataCadastro] [int] NULL,
	[Situacao] [nchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalProduto]    Script Date: 10/21/2012 23:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalProduto](
	[ProdutoGradeID] [int] NULL,
	[LocalID] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__AcessoGru__Acess__160F4887]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[AcessoGrupoUsuario]  WITH CHECK ADD FOREIGN KEY([AcessoID])
REFERENCES [dbo].[Acesso] ([ID])
GO
/****** Object:  ForeignKey [FK__AcessoGru__Grupo__17036CC0]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[AcessoGrupoUsuario]  WITH CHECK ADD FOREIGN KEY([GrupoUsuarioID])
REFERENCES [dbo].[AcessoGrupoUsuario] ([ID])
GO
/****** Object:  ForeignKey [FK__Caixa__CaixaDiaI__17F790F9]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Caixa]  WITH CHECK ADD FOREIGN KEY([CaixaDiaID])
REFERENCES [dbo].[CaixaDia] ([ID])
GO
/****** Object:  ForeignKey [FK__CaixaDia__FluxoC__18EBB532]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[CaixaDia]  WITH CHECK ADD FOREIGN KEY([FluxoCaixaID])
REFERENCES [dbo].[FluxoCaixa] ([ID])
GO
/****** Object:  ForeignKey [FK__CaixaDia__Funcio__19DFD96B]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[CaixaDia]  WITH CHECK ADD FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([ID])
GO
/****** Object:  ForeignKey [FK__Cargo__SetorID__1AD3FDA4]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD FOREIGN KEY([SetorID])
REFERENCES [dbo].[Setor] ([ID])
GO
/****** Object:  ForeignKey [FK__Compra__Funciona__1BC821DD]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([ID])
GO
/****** Object:  ForeignKey [FK__Compra__PessoaJu__1CBC4616]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([PessoaJuridicaID])
REFERENCES [dbo].[PessoaJuridica] ([ID])
GO
/****** Object:  ForeignKey [FK__Endereco__uf_id__4A8310C6]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD FOREIGN KEY([uf_id])
REFERENCES [dbo].[Uf] ([Id])
GO
/****** Object:  ForeignKey [FK__Estoque__Produto__1DB06A4F]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produto] ([ID])
GO
/****** Object:  ForeignKey [FK__FluxoCaix__Compr__1EA48E88]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[FluxoCaixa]  WITH CHECK ADD FOREIGN KEY([CompraID])
REFERENCES [dbo].[Compra] ([ID])
GO
/****** Object:  ForeignKey [FK__FluxoCaix__Lanca__1F98B2C1]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[FluxoCaixa]  WITH CHECK ADD FOREIGN KEY([LancamentoID])
REFERENCES [dbo].[Lancamento] ([ID])
GO
/****** Object:  ForeignKey [FK__FluxoCaix__TipoO__208CD6FA]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[FluxoCaixa]  WITH CHECK ADD FOREIGN KEY([TipoOperacaoID])
REFERENCES [dbo].[TipoOperacao] ([ID])
GO
/****** Object:  ForeignKey [FK__FluxoCaix__Troca__2180FB33]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[FluxoCaixa]  WITH CHECK ADD FOREIGN KEY([TrocaID])
REFERENCES [dbo].[Troca] ([ID])
GO
/****** Object:  ForeignKey [FK__FluxoCaix__Venda__22751F6C]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[FluxoCaixa]  WITH CHECK ADD FOREIGN KEY([VendaID])
REFERENCES [dbo].[Venda] ([ID])
GO
/****** Object:  ForeignKey [FK__Funcionar__Cargo__236943A5]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD FOREIGN KEY([CargoID])
REFERENCES [dbo].[Cargo] ([ID])
GO
/****** Object:  ForeignKey [FK__Funcionar__Pesso__245D67DE]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD FOREIGN KEY([PessoaFisicaID])
REFERENCES [dbo].[PessoaFisica] ([ID])
GO
/****** Object:  ForeignKey [FK__Lancament__TipoD__25518C17]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD FOREIGN KEY([TipoDocumentoID])
REFERENCES [dbo].[TipoDocumento] ([ID])
GO
/****** Object:  ForeignKey [FK__Lancament__Lanca__2645B050]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[LancamentoFinanceiro]  WITH CHECK ADD FOREIGN KEY([LancamentoID])
REFERENCES [dbo].[Lancamento] ([ID])
GO
/****** Object:  ForeignKey [FK__Local__Prateleir__2739D489]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Local]  WITH CHECK ADD FOREIGN KEY([PrateleiraID])
REFERENCES [dbo].[Prateleira] ([ID])
GO
/****** Object:  ForeignKey [FK__LocalProd__Local__282DF8C2]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[LocalProduto]  WITH CHECK ADD FOREIGN KEY([LocalID])
REFERENCES [dbo].[Local] ([ID])
GO
/****** Object:  ForeignKey [FK__LocalProd__Produ__29221CFB]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[LocalProduto]  WITH CHECK ADD FOREIGN KEY([ProdutoGradeID])
REFERENCES [dbo].[ProdutoGrade] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__Compr__2A164134]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD FOREIGN KEY([CompraID])
REFERENCES [dbo].[Compra] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__Produ__2B0A656D]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produto] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__TipoO__2BFE89A6]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD FOREIGN KEY([TipoOperacaoID])
REFERENCES [dbo].[TipoOperacao] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__Troca__2CF2ADDF]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD FOREIGN KEY([TrocaID])
REFERENCES [dbo].[Troca] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__Venda__2DE6D218]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[Movimentacao]  WITH CHECK ADD FOREIGN KEY([VendaID])
REFERENCES [dbo].[Venda] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimenta__Parce__2EDAF651]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[MovimentacaoParcelas]  WITH CHECK ADD FOREIGN KEY([ParcelaID])
REFERENCES [dbo].[Parcelas] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimento__Pesso__2FCF1A8A]    Script Date: 10/21/2012 23:26:24 ******/
ALTER TABLE [dbo].[MovimentoEstoque]  WITH CHECK ADD FOREIGN KEY([PessoaJuridicaID])
REFERENCES [dbo].[PessoaJuridica] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimento__Pesso__30C33EC3]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[MovimentoEstoque]  WITH CHECK ADD FOREIGN KEY([PessoaFisicaID])
REFERENCES [dbo].[PessoaFisica] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimento__TipoO__31B762FC]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[MovimentoEstoque]  WITH CHECK ADD FOREIGN KEY([TipoOperacaoID])
REFERENCES [dbo].[TipoOperacao] ([ID])
GO
/****** Object:  ForeignKey [FK__Movimento__MovEs__32AB8735]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[MovimentoEstoqueItem]  WITH CHECK ADD FOREIGN KEY([MovEstoqueID])
REFERENCES [dbo].[MovimentoEstoque] ([MovEstoqueID])
GO
/****** Object:  ForeignKey [FK__Movimento__Produ__339FAB6E]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[MovimentoEstoqueItem]  WITH CHECK ADD FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produto] ([ID])
GO
/****** Object:  ForeignKey [FK__Parcelas__FluxoC__3493CFA7]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Parcelas]  WITH CHECK ADD FOREIGN KEY([FluxoCaixaID])
REFERENCES [dbo].[FluxoCaixa] ([ID])
GO
/****** Object:  ForeignKey [FK__PessoaFis__Ender__3587F3E0]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[Endereco] ([ID])
GO
/****** Object:  ForeignKey [FK__PessoaFis__Sexo___367C1819]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[PessoaFisica]  WITH CHECK ADD FOREIGN KEY([Sexo_Id])
REFERENCES [dbo].[Sexo] ([ID])
GO
/****** Object:  ForeignKey [FK__PessoaJur__Ender__37703C52]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[PessoaJuridica]  WITH CHECK ADD FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[MovimentoEstoque] ([MovEstoqueID])
GO
/****** Object:  ForeignKey [FK__Preco__PromocaoI__3864608B]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Preco]  WITH CHECK ADD FOREIGN KEY([PromocaoID])
REFERENCES [dbo].[Promocao] ([ID])
GO
/****** Object:  ForeignKey [FK__Produto__Categor__395884C4]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([ID])
GO
/****** Object:  ForeignKey [FK__Produto__Comissa__3A4CA8FD]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD FOREIGN KEY([ComissaoID])
REFERENCES [dbo].[Comissao] ([ID])
GO
/****** Object:  ForeignKey [FK__Produto__MarcaID__3B40CD36]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD FOREIGN KEY([MarcaID])
REFERENCES [dbo].[Marca] ([ID])
GO
/****** Object:  ForeignKey [FK__Produto__PrecoID__3C34F16F]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD FOREIGN KEY([PrecoID])
REFERENCES [dbo].[Preco] ([ID])
GO
/****** Object:  ForeignKey [FK__ProdutoGr__Grade__3D2915A8]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[ProdutoGrade]  WITH CHECK ADD FOREIGN KEY([GradeID])
REFERENCES [dbo].[Grade] ([ID])
GO
/****** Object:  ForeignKey [FK__ProdutoGr__Produ__3E1D39E1]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[ProdutoGrade]  WITH CHECK ADD FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produto] ([ID])
GO
/****** Object:  ForeignKey [FK__Troca__Funcionar__3F115E1A]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Troca]  WITH CHECK ADD FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([ID])
GO
/****** Object:  ForeignKey [FK__Troca__PessoaFis__40058253]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Troca]  WITH CHECK ADD FOREIGN KEY([PessoaFisicaID])
REFERENCES [dbo].[PessoaFisica] ([ID])
GO
/****** Object:  ForeignKey [FK__Troca__PessoaJur__40F9A68C]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Troca]  WITH CHECK ADD FOREIGN KEY([PessoaJuridicaID])
REFERENCES [dbo].[PessoaJuridica] ([ID])
GO
/****** Object:  ForeignKey [FK__Usuario__Funcion__41EDCAC5]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([ID])
GO
/****** Object:  ForeignKey [FK__Usuario__GrupoUs__42E1EEFE]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([GrupoUsuarioID])
REFERENCES [dbo].[GrupoUsuario] ([ID])
GO
/****** Object:  ForeignKey [FK__Venda__Funcionar__43D61337]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([ID])
GO
/****** Object:  ForeignKey [FK__Venda__PessoaFis__44CA3770]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([PessoaFisicaID])
REFERENCES [dbo].[PessoaFisica] ([ID])
GO
/****** Object:  ForeignKey [FK__Venda__PessoaJur__45BE5BA9]    Script Date: 10/21/2012 23:26:25 ******/
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([PessoaJuridicaID])
REFERENCES [dbo].[PessoaJuridica] ([ID])
GO
