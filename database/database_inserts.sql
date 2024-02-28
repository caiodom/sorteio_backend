INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8430f2f5-6864-479a-aab0-3c824755627e', N'admin@teste.com.br', N'ADMIN@TESTE.COM.BR', N'admin@teste.com.br', N'ADMIN@TESTE.COM.BR', 1, N'AQAAAAIAAYagAAAAEKVEsOFWBdxSAsh5dbZ70ZSd4hdxR8OsyGdvEXsNrhu7hnvtya2WTd5pP+P3Dkj2DA==', N'', N'ea7542ae-e357-415b-bfa5-10c0b77ef0ca', NULL, 0, 0, NULL, 0, 0)

SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'8430f2f5-6864-479a-aab0-3c824755627e', N'DadosSorteio', N'Adicionar,Atualizar,Excluir')
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'8430f2f5-6864-479a-aab0-3c824755627e', N'HistoricoSorteio', N'Adicionar,Atualizar,Excluir')
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, N'8430f2f5-6864-479a-aab0-3c824755627e', N'ParticipanteSorteio', N'Adicionar,Atualizar,Excluir')
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (4, N'8430f2f5-6864-479a-aab0-3c824755627e', N'TicketSorteio', N'Adicionar,Atualizar,Excluir')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF

--Admin 
--user:admin@teste.com.br
--password: Admin@1234