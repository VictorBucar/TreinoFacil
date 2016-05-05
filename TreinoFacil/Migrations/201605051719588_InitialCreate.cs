namespace TreinoFacil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        PrimeiroNome = c.String(),
                        UltimoNome = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Endereco = c.String(),
                        DataInicioTreino = c.DateTime(nullable: false),
                        DataFimTreino = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoID);
            
            CreateTable(
                "dbo.Treinoes",
                c => new
                    {
                        TreinoID = c.Int(nullable: false, identity: true),
                        NomeTreino = c.String(),
                        TipoTreino = c.String(),
                        Status = c.Int(),
                        FrequenciaSemanal = c.String(),
                        AlunoID = c.Int(nullable: false),
                        ProfessorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreinoID)
                .ForeignKey("dbo.Alunoes", t => t.AlunoID, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.ProfessorID, cascadeDelete: true)
                .Index(t => t.AlunoID)
                .Index(t => t.ProfessorID);
            
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        AtividadeID = c.Int(nullable: false, identity: true),
                        NomeAtividade = c.String(),
                        Categoria = c.String(),
                        FrequenciaSemanal = c.String(),
                        TempoTotal = c.String(),
                    })
                .PrimaryKey(t => t.AtividadeID);
            
            CreateTable(
                "dbo.Exercicios",
                c => new
                    {
                        ExercicioID = c.Int(nullable: false, identity: true),
                        NomeExercicio = c.String(),
                        Categoria = c.String(),
                        Intensidade = c.String(),
                        Carga = c.Int(nullable: false),
                        QntdRepeticao = c.Int(nullable: false),
                        Tempo = c.String(),
                        AtividadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExercicioID)
                .ForeignKey("dbo.Atividades", t => t.AtividadeID, cascadeDelete: true)
                .Index(t => t.AtividadeID);
            
            CreateTable(
                "dbo.Equipamentoes",
                c => new
                    {
                        EquipamentoID = c.Int(nullable: false, identity: true),
                        NomeEquipamento = c.String(),
                        MusculoAlvo = c.String(),
                    })
                .PrimaryKey(t => t.EquipamentoID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false, identity: true),
                        PrimeiroNome = c.String(),
                        UltimoNome = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Endereco = c.String(),
                        CREF = c.String(),
                        Formacao = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EquipamentoExercicios",
                c => new
                    {
                        Equipamento_EquipamentoID = c.Int(nullable: false),
                        Exercicio_ExercicioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipamento_EquipamentoID, t.Exercicio_ExercicioID })
                .ForeignKey("dbo.Equipamentoes", t => t.Equipamento_EquipamentoID, cascadeDelete: true)
                .ForeignKey("dbo.Exercicios", t => t.Exercicio_ExercicioID, cascadeDelete: true)
                .Index(t => t.Equipamento_EquipamentoID)
                .Index(t => t.Exercicio_ExercicioID);
            
            CreateTable(
                "dbo.AtividadeTreinoes",
                c => new
                    {
                        Atividade_AtividadeID = c.Int(nullable: false),
                        Treino_TreinoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Atividade_AtividadeID, t.Treino_TreinoID })
                .ForeignKey("dbo.Atividades", t => t.Atividade_AtividadeID, cascadeDelete: true)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoID, cascadeDelete: true)
                .Index(t => t.Atividade_AtividadeID)
                .Index(t => t.Treino_TreinoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Treinoes", "ProfessorID", "dbo.Professors");
            DropForeignKey("dbo.AtividadeTreinoes", "Treino_TreinoID", "dbo.Treinoes");
            DropForeignKey("dbo.AtividadeTreinoes", "Atividade_AtividadeID", "dbo.Atividades");
            DropForeignKey("dbo.EquipamentoExercicios", "Exercicio_ExercicioID", "dbo.Exercicios");
            DropForeignKey("dbo.EquipamentoExercicios", "Equipamento_EquipamentoID", "dbo.Equipamentoes");
            DropForeignKey("dbo.Exercicios", "AtividadeID", "dbo.Atividades");
            DropForeignKey("dbo.Treinoes", "AlunoID", "dbo.Alunoes");
            DropIndex("dbo.AtividadeTreinoes", new[] { "Treino_TreinoID" });
            DropIndex("dbo.AtividadeTreinoes", new[] { "Atividade_AtividadeID" });
            DropIndex("dbo.EquipamentoExercicios", new[] { "Exercicio_ExercicioID" });
            DropIndex("dbo.EquipamentoExercicios", new[] { "Equipamento_EquipamentoID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Exercicios", new[] { "AtividadeID" });
            DropIndex("dbo.Treinoes", new[] { "ProfessorID" });
            DropIndex("dbo.Treinoes", new[] { "AlunoID" });
            DropTable("dbo.AtividadeTreinoes");
            DropTable("dbo.EquipamentoExercicios");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Professors");
            DropTable("dbo.Equipamentoes");
            DropTable("dbo.Exercicios");
            DropTable("dbo.Atividades");
            DropTable("dbo.Treinoes");
            DropTable("dbo.Alunoes");
        }
    }
}
