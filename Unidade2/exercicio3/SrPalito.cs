using System;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL4;

namespace gcgcg
{
  internal class SrPalito : Objeto
  {

    public SrPalito(Objeto _paiRef, ref char _rotulo) : base(_paiRef, ref _rotulo)
    {
      var rotuloCabeca = 'c';
      Objeto cabeca = new Objeto(this, ref rotuloCabeca);
      constroiCirculo(cabeca, 0.5);

      var rotuloCorpo = 'b';
      Objeto corpoObj = new Objeto(this, ref rotuloCorpo);
      corpo(corpoObj, new Ponto4D(0, -0.5), new Ponto4D(0, -1.4)); 

      Atualizar();
    }

    private void constroiCirculo(Objeto destino, Double raio)
    {
      destino.PrimitivaTipo = PrimitiveType.LineLoop;
      destino.PrimitivaTamanho = 1;

      for (int i = 0; i < 72; i++)
      {
        double angulo = (2 * 3.14 * i) / 72;
        double x = raio * Math.Cos(angulo);
        double y = raio * Math.Sin(angulo);

        destino.PontosAdicionar(new Ponto4D(x, y));
      }
    }

    private void corpo(Objeto destino, Ponto4D ptoIni, Ponto4D ptoFim)
    {
      destino.PrimitivaTipo = PrimitiveType.Lines;
      destino.PrimitivaTamanho = 10;

      destino.PontosAdicionar(ptoIni);
      destino.PontosAdicionar(ptoFim);
    }

    public void atualizarRaio(Double raioInc) {
      var rotuloCabeca = 'c';
      Objeto cabeca = new Objeto(this, ref rotuloCabeca);
      constroiCirculo(cabeca, raioInc);

      var rotuloCorpo = 'b';
      Objeto corpoObj = new Objeto(this, ref rotuloCorpo);
      corpo(corpoObj, new Ponto4D(0, -0.5), new Ponto4D(0, -1.4)); 

      Atualizar();
    }

    private void Atualizar()
    {
      base.ObjetoAtualizar();
    }

#if CG_Debug
    public override string ToString()
    {
      System.Console.WriteLine("__________________________________ \n");
      string retorno;
      retorno = "__ Objeto Circulo _ Tipo: " + PrimitivaTipo + " _ Tamanho: " + PrimitivaTamanho + "\n";
      retorno += base.ImprimeToString();
      return retorno;
    }
#endif

  }
}
