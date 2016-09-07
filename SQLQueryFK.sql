ALTER TABLE [Employees]  WITH CHECK ADD  CONSTRAINT [FK_Department] FOREIGN KEY([DepartmentId])
REFERENCES [Department] ([DepartmentId])
GO