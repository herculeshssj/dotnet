/*
 * https://www.guj.com.br/t/resolvido-gerar-todas-as-3-268-760-combinacoes-da-lotofacil/93028/8
 * 
 * Segue um algoritmo que fiz para um projeto particular que está inacabado. Gera combinações com qualquer quantidade de valores.

 Atenção no método main, para testar coloque combinações que resultem em poucos jogos tipo geraCombinacao(17, 15) e retire os comentários das linhas com print e println, desta forma verá os 136 jogos gerados.
 */

import java.math.BigInteger;

public class Combina {

	public static int possibities(int n, int p) {
		if (n == p)
			return 1;
		BigInteger nFat = factorial(n);
		BigInteger pFat = factorial(p);
		BigInteger nMinusPFat = factorial(n - p);
		BigInteger result = nFat.divide(pFat.multiply(nMinusPFat));
		return result.intValue();
	}

	public static BigInteger factorial(final int n) {
		BigInteger result = BigInteger.valueOf(n);
		for (int i = n - 1; i > 0; i--)
			result = result.multiply(BigInteger.valueOf(i));
		return result;
	}

	public static int[][] geraCombinacao(int n, int p) {
		int c = possibities(n, p);
		int[][] m = new int[c][p];
		int[] vN = new int[p];

		for (int i = 0; i < p; i++) {
			vN[i] = i;
			m[0][i] = i;
		}

		for (int i = 1; i < c; i++)
			for (int j = p - 1; j >= 0; j--)
				if (vN[j] < (n - p + j)) {
					vN[j]++;
					for (int k = j + 1; k < p; k++) {
						vN[k] = vN[j] + k - j;
					}
					for (int l = 0; l < p; l++) {
						m[i][l] = vN[l];
					}

					break;
				}

		return m;
	}

	public static void main(String[] args) {
		int[][] m = geraCombinacao(25, 15); // coloque aqui (total de dezenas,dezenas por grupo)
		for (int i = 0; i < m.length; i++) {
			for (int j = 0; j < m[i].length; j++) {
				System.out.print(String.format("%02d ", (m[i][j] + 1)) + " ");
			}
			System.out.println();
		}
		System.out.println("Total de " + m.length + " combinações");

	}

}