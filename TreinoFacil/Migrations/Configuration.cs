namespace TreinoFacil.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TreinoFacil.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TreinoFacil.Models.ApplicationDbContext context)
        {

            context.Alunoes.Add(new Aluno { PrimeiroNome = "Carson", UltimoNome = "Alexander", Email = "carson@gmail.com", Login = "CarsonAle", Senha = "123456", Endereco = "Nova colina - Sobradinho", DataInicioTreino = DateTime.Parse("2016-03-18"), DataFimTreino = DateTime.Parse("2016-06-18") });
            context.SaveChanges();
            context.Alunoes.Add(new Aluno { PrimeiroNome = "Luiz", UltimoNome = "Pereira", Email = "luiz@gmail.com", Login = "luizp", Senha = "123456", Endereco = "Jaboatão da serra - ", DataInicioTreino = DateTime.Parse("2016-03-19"), DataFimTreino = DateTime.Parse("2016-05-18") });
            context.SaveChanges();
            context.Alunoes.Add(new Aluno { PrimeiroNome = "José", UltimoNome = "Da Silva", Email = "jose@gmail.com", Login = "josesilva", Senha = "1234567", Endereco = "Quadra 4 cj 1", DataInicioTreino = DateTime.Parse("2016-03-08"), DataFimTreino = DateTime.Parse("2016-04-18") });
            context.SaveChanges();
            context.Alunoes.Add(new Aluno { PrimeiroNome = "Carlos", UltimoNome = "Souza", Email = "carlos@gmail.com", Login = "carlosS", Senha = "12345678", Endereco = "Nova York", DataInicioTreino = DateTime.Parse("2016-03-12"), DataFimTreino = DateTime.Parse("2016-07-18") });
            context.SaveChanges();


            context.Professors.Add(new Professor { PrimeiroNome = "Alberto", UltimoNome = "Braga", CREF = "1050-DF", Email = "Alberto@gmail.com", Login = "CarsonAle", Senha = "123456", Endereco = "Rua das camélias", Formacao = "Mestre" });
            context.SaveChanges();
            context.Professors.Add(new Professor { PrimeiroNome = "Victor", UltimoNome = "Bucar", CREF = "4022=SP", Email = "victor@gmail.com", Login = "CarsonAle", Senha = "123456", Endereco = "Morada Colonial", Formacao = "Mestre" });
            context.SaveChanges();
            context.Professors.Add(new Professor { PrimeiroNome = "Almir", UltimoNome = "Sater", CREF = "4041-DF", Email = "almir@gmail.com", Login = "CarsonAle", Senha = "123456", Endereco = "Rua das camélias", Formacao = "Mestre" });
            context.SaveChanges();
            context.Professors.Add(new Professor { PrimeiroNome = "Maria", UltimoNome = "Almeida", CREF = "1045-GO", Email = "maria@hotmail.com", Login = "CarsonAle", Senha = "123456", Endereco = "Morada Colonial", Formacao = "Doutor" });
            context.SaveChanges();


            context.Treinoes.Add(new Treino { TreinoID = 1, AlunoID = 1, ProfessorID = 1, NomeTreino = "Treino 1", Status = Status.Ativo });
            context.SaveChanges();
            context.Treinoes.Add(new Treino { TreinoID = 1, AlunoID = 2, ProfessorID = 2, NomeTreino = "Treino 2", Status = Status.Ativo });
            context.SaveChanges();
            context.Treinoes.Add(new Treino { TreinoID = 1, AlunoID = 4, ProfessorID = 4, NomeTreino = "Treino 3", Status = Status.Aguardando });
            context.SaveChanges();
            context.Treinoes.Add(new Treino { TreinoID = 2, AlunoID = 3, ProfessorID = 3, NomeTreino = "Treino 4", Status = Status.Inativo });
            context.SaveChanges();


            context.Atividades.Add(new Atividade { AtividadeID = 1, NomeAtividade = "Cross-fit", Categoria = "Melhoramento Físico", FrequenciaSemanal = "2x", TempoTotal = "30min" });
            context.SaveChanges();
            context.Atividades.Add(new Atividade { AtividadeID = 2, NomeAtividade = "Musculação", Categoria = "Levantamento de peso", FrequenciaSemanal = "2x", TempoTotal = "30min" });
            context.SaveChanges();
            context.Atividades.Add(new Atividade { AtividadeID = 3, NomeAtividade = "Condicionamento Físico", Categoria = "Melhoramento Físico", FrequenciaSemanal = "2x", TempoTotal = "30 min" });
            context.SaveChanges();


            context.Exercicios.Add(new Exercicio { ExercicioID = 1, AtividadeID = 1, NomeExercicio = "Agachamento", Categoria = "Musculos inferiores", Intensidade = "Moderada", Carga = 10, QntdRepeticao = 15, Tempo = "1 min" });
            context.SaveChanges();
            context.Exercicios.Add(new Exercicio { ExercicioID = 2, AtividadeID = 2, NomeExercicio = "Supino reto", Categoria = "Musculos superiores", Intensidade = "Moderada", Carga = 25, QntdRepeticao = 15, Tempo = "1 min" });
            context.SaveChanges();
            context.Exercicios.Add(new Exercicio { ExercicioID = 3, AtividadeID = 3, NomeExercicio = "Corrida", Categoria = "Musculos posteriores e inferiores", Intensidade = "Leve", Carga = 0, QntdRepeticao = 15, Tempo = "20 min" });
            context.SaveChanges();


            context.Equipamentoes.Add(new Equipamento { EquipamentoID = 1, NomeEquipamento = "Leg-press", MusculoAlvo = "Coxa" });
            context.SaveChanges();
            context.Equipamentoes.Add(new Equipamento { EquipamentoID = 2, NomeEquipamento = "Supino", MusculoAlvo = "Peitoral" });
            context.SaveChanges();
            context.Equipamentoes.Add(new Equipamento { EquipamentoID = 3, NomeEquipamento = "Esteira", MusculoAlvo = "Superiores e Inferiores" });
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
