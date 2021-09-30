using Indicadores.Datos.Mapping.Almacen;
using Indicadores.Datos.Mapping.Bitacora;
using Indicadores.Datos.Mapping.Descripcion;
using Indicadores.Datos.Mapping.Horario;
using Indicadores.Datos.Mapping.Ubicacion;
using Indicadores.Datos.Mapping.Usuarios;
using Indicadores.Datos.Mapping.Impresion;
using Indicadores.Entidades.Almacen;
using Indicadores.Entidades.Bitacora;
using Indicadores.Entidades.Descripcion;
using Indicadores.Entidades.Horario;
using Indicadores.Entidades.Impresion;
using Indicadores.Entidades.Ubicacion;
using Indicadores.Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Indicadores.Datos.Mapping.Computo;
using Indicadores.Entidades.Computo;

namespace Indicadores.Datos
{
    public class DbContextIndicadores : DbContext
    {
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<TipoActividad> TipoActividades { get; set; }
        public DbSet<ActividadAdm> ActividadAdms { get; set; }
        public DbSet<Desc> Descripciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atribuible> Atribuibles { get; set; }
        public DbSet<Hoja> Hojas { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TipoFalla> TipoFallas { get; set; }
        public DbSet<CatFalla> CatFallas { get; set; }
        public DbSet<CausaFalla> CausaFallas { get; set; }
        public DbSet<Solucion> Soluciones { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<AreaFuncional> AreasFuncionales { get; set; }
        public DbSet<UbicacionFuncional> UbicacionesFuncionales { get; set; }
        public DbSet<TipoSol> TipoSols { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Impresora> Impresoras { get; set; }
        public DbSet<ControlToner> ControlToners { get; set; }
        public DbSet<ReporteMes> ReportesMes { get; set; }
        public DbSet<Blade> Blades { get; set; }
        public DbSet<Cube> Cubes { get; set; }
        public DbSet<AlmacenImpresion> AlmacenImpresiones { get; set; }


        public DbContextIndicadores(DbContextOptions<DbContextIndicadores> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PartidaMap());
            modelBuilder.ApplyConfiguration(new DispositivoMap());
            modelBuilder.ApplyConfiguration(new ActividadMap());
            modelBuilder.ApplyConfiguration(new TipoActividadMap());
            modelBuilder.ApplyConfiguration(new ActividadAdmMap());
            modelBuilder.ApplyConfiguration(new DescripcionMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new PuestoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AtribuibleMap());
            modelBuilder.ApplyConfiguration(new HojaMap());
            modelBuilder.ApplyConfiguration(new RegistroMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new TipoFallaMap());
            modelBuilder.ApplyConfiguration(new CatFallaMap());
            modelBuilder.ApplyConfiguration(new CausaFallaMap());
            modelBuilder.ApplyConfiguration(new SolucionMap());
            modelBuilder.ApplyConfiguration(new HerramientaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new InsumoMap());
            modelBuilder.ApplyConfiguration(new AreaFuncionalMap());
            modelBuilder.ApplyConfiguration(new UbicacionFuncionalMap());
            modelBuilder.ApplyConfiguration(new TipoSolMap());
            modelBuilder.ApplyConfiguration(new TurnoMap());
            modelBuilder.ApplyConfiguration(new ImpresoraMap());
            modelBuilder.ApplyConfiguration(new ControlTonerMap());
            modelBuilder.ApplyConfiguration(new ReporteMesMap());
            modelBuilder.ApplyConfiguration(new CubeMap());
            modelBuilder.ApplyConfiguration(new BladeMap());
            modelBuilder.ApplyConfiguration(new AlmacenImpresionMap());
        }
    }
}
