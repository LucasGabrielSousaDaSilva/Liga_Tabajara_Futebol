namespace Liga_Tabajara_Futebol.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Liga_Tabajara_Futebol.DAL.LigaTabajaraFutebol>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Liga_Tabajara_Futebol.DAL.LigaTabajaraFutebol context)
        {
            var liga = new Models.Liga
            {
                Status = true
            };
            context.Ligas.AddOrUpdate(l => l.Id, liga);

            var time1 = new Models.Time
            {
                Nome = "Time A",
                Status = true,
                CorUniformesPrimaria = "Azul",
                CorUniformesSecundaria = "Branco",
                DataFundacao = DateTime.Now,
                Cidade = "Cidade A",
                Estado = "Estado A",
                Estadio = "Estádio A",
                CapacidadeEstagio = 50000,
                LigaId = liga.Id
            };
            var time2 = new Models.Time
            {
                Nome = "Time B",
                Status = true,
                CorUniformesPrimaria = "Vermelho",
                CorUniformesSecundaria = "Preto",
                DataFundacao = DateTime.Now,
                Cidade = "Cidade B",
                Estado = "Estado B",
                Estadio = "Estádio B",
                CapacidadeEstagio = 60000,
                LigaId = liga.Id
            };
            var time3 = new Models.Time {
                Nome = "Time C",
                Status = true,
                CorUniformesPrimaria = "Verde",
                CorUniformesSecundaria = "Amarelo",
                DataFundacao = DateTime.Now,
                Cidade = "Cidade C",
                Estado = "Estado C",
                Estadio = "Estádio C",
                CapacidadeEstagio = 70000,
                LigaId = liga.Id
            };
            var time4 = new Models.Time {
                Nome = "Time D",
                Status = true,
                CorUniformesPrimaria = "Preto",
                CorUniformesSecundaria = "Branco",
                DataFundacao = DateTime.Now,
                Cidade = "Cidade D",
                Estado = "Estado D",
                Estadio = "Estádio D",
                CapacidadeEstagio = 80000,
                LigaId = liga.Id
            };
            var time5 = new Models.Time {
                Nome = "Time E",
                Status = true,
                CorUniformesPrimaria = "Amarelo",
                CorUniformesSecundaria = "Azul",
                DataFundacao = DateTime.Now,
                Cidade = "Cidade E",
                Estado = "Estado E",
                Estadio = "Estádio E",
                CapacidadeEstagio = 90000,
                LigaId = liga.Id
            };
            context.Times.AddOrUpdate(t => t.Id, time1, time2, time3, time4, time5);

            var jogador1 = new Models.Jogador
            {
                Nome = "Jogador 1",
                DataNascimento = DateTime.Now,
                Nacionalidade = "Nacionalidade 1",
                Posicao = Models.Posicao.Atacante,
                NumCamisa = 10,
                Altura = 1.80f,
                Peso = 75f,
                PePreferido = Models.PePreferido.Direito,
                Time = time1
            };

            var jogador2 = new Models.Jogador
            {
                Nome = "Jogador 2",
                DataNascimento = DateTime.Now,
                Nacionalidade = "Nacionalidade 2",
                Posicao = Models.Posicao.MeioCampo,
                NumCamisa = 8,
                Altura = 1.75f,
                Peso = 70f,
                PePreferido = Models.PePreferido.Esquerdo,
                Time = time2
            };
            var jogador3 = new Models.Jogador
            {
                Nome = "Jogador 3",
                DataNascimento = DateTime.Now,
                Nacionalidade = "Nacionalidade 3",
                Posicao = Models.Posicao.Zagueiro,
                NumCamisa = 5,
                Altura = 1.85f,
                Peso = 80f,
                PePreferido = Models.PePreferido.Ambidestro,
                Time = time3
            };
            var jogador4 = new Models.Jogador
            {
                Nome = "Jogador 4",
                DataNascimento = DateTime.Now,
                Nacionalidade = "Nacionalidade 4",
                Posicao = Models.Posicao.Goleiro,
                NumCamisa = 1,
                Altura = 1.90f,
                Peso = 85f,
                PePreferido = Models.PePreferido.Direito,
                Time = time4
            };
            var jogador5 = new Models.Jogador
            {
                Nome = "Jogador 5",
                DataNascimento = DateTime.Now,
                Nacionalidade = "Nacionalidade 5",
                Posicao = Models.Posicao.Lateral,
                NumCamisa = 2,
                Altura = 1.78f,
                Peso = 72f,
                PePreferido = Models.PePreferido.Esquerdo,
                Time = time5
            };
            context.Jogadores.AddOrUpdate(j => j.Id, jogador1, jogador2, jogador3, jogador4, jogador5);

            var partida = new Models.Partida
            {
                Data = DateTime.Now,
                Estadio = "Estádio A",
                TimeCasaId = time1,
                TimeForaId = time2
            };
            var partida2 = new Models.Partida
            {
                Data = DateTime.Now,
                Estadio = "Estádio B",
                TimeCasaId = time3,
                TimeForaId = time4
            };
            var partida3 = new Models.Partida
            {
                Data = DateTime.Now,
                Estadio = "Estádio C",
                TimeCasaId = time5,
                TimeForaId = time1
            };
            var partida4 = new Models.Partida
            {
                Data = DateTime.Now,
                Estadio = "Estádio D",
                TimeCasaId = time2,
                TimeForaId = time3
            };
            var partida5 = new Models.Partida
            {
                Data = DateTime.Now,
                Estadio = "Estádio E",
                TimeCasaId = time4,
                TimeForaId = time5
            };
            context.Partidas.AddOrUpdate(p => p.Id, partida, partida2, partida3, partida4, partida5);

            var estatisticaPartida = new Models.EstatisticaPartida
            {
                PartidaId = partida.Id,
                JogadorId = jogador1.Id,
                TimeId = time1.Id,
                GolsMarcados = 2,
                GolsSofridos = 0,
                Asistencias = 1,
                CartoesAmarelos = 0,
                CartoesVermelhos = 0
            };
            var estatisticaPartida2 = new Models.EstatisticaPartida
            {
                PartidaId = partida2.Id,
                JogadorId = jogador2.Id,
                TimeId = time2.Id,
                GolsMarcados = 1,
                GolsSofridos = 0,
                Asistencias = 0,
                CartoesAmarelos = 1,
                CartoesVermelhos = 0
            };
            var estatisticaPartida3 = new Models.EstatisticaPartida
            {
                PartidaId = partida3.Id,
                JogadorId = jogador3.Id,
                TimeId = time3.Id,
                GolsMarcados = 0,
                GolsSofridos = 1,
                Asistencias = 0,
                CartoesAmarelos = 0,
                CartoesVermelhos = 1
            };
            var estatisticaPartida4 = new Models.EstatisticaPartida
            {
                PartidaId = partida4.Id,
                JogadorId = jogador4.Id,
                TimeId = time4.Id,
                GolsMarcados = 1,
                GolsSofridos = 0,
                Asistencias = 0,
                CartoesAmarelos = 0,
                CartoesVermelhos = 0
            };
            var estatisticaPartida5 = new Models.EstatisticaPartida
            {
                PartidaId = partida5.Id,
                JogadorId = jogador5.Id,
                TimeId = time5.Id,
                GolsMarcados = 0,
                GolsSofridos = 2,
                Asistencias = 1,
                CartoesAmarelos = 0,
                CartoesVermelhos = 0
            };
            context.EstatisticasPartida.AddOrUpdate(e => e.Id, estatisticaPartida, estatisticaPartida2, estatisticaPartida3, estatisticaPartida4, estatisticaPartida5);

            var comissaoTecnica = new Models.ComissaoTecnica
            {
                Nome = "Comissão Técnica A",
                Cargo = Models.Cargo.Treinador,
                DataNascimento = DateTime.Now,
                Time = time1
            };
            var comissaoTecnica2 = new Models.ComissaoTecnica
            {
                Nome = "Comissão Técnica B",
                Cargo = Models.Cargo.Auxiliar,
                DataNascimento = DateTime.Now,
                Time = time2
            };
            var comissaoTecnica3 = new Models.ComissaoTecnica
            {
                Nome = "Comissão Técnica C",
                Cargo = Models.Cargo.PreparadorFisico,
                DataNascimento = DateTime.Now,
                Time = time3
            };
            var comissaoTecnica4 = new Models.ComissaoTecnica
            {
                Nome = "Comissão Técnica D",
                Cargo = Models.Cargo.Massagista,
                DataNascimento = DateTime.Now,
                Time = time4
            };
            var comissaoTecnica5 = new Models.ComissaoTecnica
            {
                Nome = "Comissão Técnica E",
                Cargo = Models.Cargo.Medico,
                DataNascimento = DateTime.Now,
                Time = time5
            };
            context.ComissaoTecnica.AddOrUpdate(c => c.Id, comissaoTecnica, comissaoTecnica2, comissaoTecnica3, comissaoTecnica4, comissaoTecnica5);

            context.SaveChanges();

        }
    }
}
