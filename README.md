## Helpers CSharp

### Formatações:

- Cpf Cnpj:
- Cep
- Valores Númericos com e sem o prefixo R$ ou $

### Como usar:

Basta copiar o *Helper* para seu projeto e adicionar o namespace na classe que deseja usar, ex:

```c#
using System;
using SEU_NAMESPACE_HELPER;

namespace Main
{
    class Program
    {
        public class MeuObj
        {
            public string CpfCnpj { get; set; }
            public double Valor { get; set; }
            public string ValorFormatado => Valor.MaskCurrencyWithPrefix(true, 2);
            public string Cep { get; set; }
        }

        static void Main(string[] args)
        {
            var meuObj = new MeuObj();
            meuObj.CpfCnpj = "12312312312".MaskCpfCnpj();
            meuObj.Valor = 122.40;
            meuObj.Cep = "78055747".MaskCep();

            Console.WriteLine($@"Resultado: {meuObj?.CpfCnpj} - Cep: {meuObj?.Cep} - Valor: {meuObj?.ValorFormatado}");
            //Resultado: 123.123.123-12 - Cep: 78055-747 - Valor: R$ 122,40
            
            Console.ReadKey();
        }
    }
}
```
