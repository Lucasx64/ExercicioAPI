using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Contexts;

public partial class EscolaContext : DbContext
{
    public EscolaContext(DbContextOptions<EscolaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Aluno { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<EspecialidadeProfessor> EspecialidadeProfessor { get; set; }

    public virtual DbSet<Matricula> Matricula { get; set; }

    public virtual DbSet<Professor> Professor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PK__ALUNO__30962D14B35CA073");

            entity.ToTable("ALUNO");

            entity.HasIndex(e => e.Email, "UQ_Aluno_Email").IsUnique();

            entity.Property(e => e.Matricula)
                .ValueGeneratedNever()
                .HasColumnName("matricula");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CodigoCurso).HasName("PK__CURSO__967F7C6ADE80E190");

            entity.ToTable("CURSO");

            entity.HasIndex(e => e.Nome, "UQ__CURSO__6F71C0DC341E0B42").IsUnique();

            entity.Property(e => e.CodigoCurso)
                .ValueGeneratedNever()
                .HasColumnName("codigo_curso");
            entity.Property(e => e.CargaHoraria).HasColumnName("carga_horaria");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.RegistroProfessor).HasColumnName("registro_professor");

            entity.HasOne(d => d.RegistroProfessorNavigation).WithMany(p => p.Curso)
                .HasForeignKey(d => d.RegistroProfessor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_curso_professor");
        });

        modelBuilder.Entity<EspecialidadeProfessor>(entity =>
        {
            entity.HasKey(e => new { e.RegistroProfessor, e.Especialidade }).HasName("pk_especialidade_professor");

            entity.ToTable("ESPECIALIDADE_PROFESSOR");

            entity.Property(e => e.RegistroProfessor).HasColumnName("registro_professor");
            entity.Property(e => e.Especialidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especialidade");

            entity.HasOne(d => d.RegistroProfessorNavigation).WithMany(p => p.EspecialidadeProfessor)
                .HasForeignKey(d => d.RegistroProfessor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_especialidade_professor");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.MatriculaAluno).HasName("PK__MATRICUL__1EB6ED69FEA700C2");

            entity.ToTable("MATRICULA");

            entity.Property(e => e.MatriculaAluno)
                .ValueGeneratedNever()
                .HasColumnName("matricula_aluno");
            entity.Property(e => e.CodigoCurso).HasColumnName("codigo_curso");
            entity.Property(e => e.DataMatricula)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_matricula");

            entity.HasOne(d => d.CodigoCursoNavigation).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.CodigoCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_matricula_codigo_curso");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.RegistroProfessor).HasName("PK__PROFESSO__5716BF62FB09F49C");

            entity.ToTable("PROFESSOR");

            entity.HasIndex(e => e.Email, "UQ__PROFESSO__AB6E61649368AA0C").IsUnique();

            entity.Property(e => e.RegistroProfessor)
                .ValueGeneratedNever()
                .HasColumnName("registro_professor");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
