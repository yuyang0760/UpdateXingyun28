// Pceggs._2存入数据库.Converts
using System;

internal class Converts
{
	public int toPC28(int[] n)
	{
		int num = 0;
		for (int i = 1; i <= 6; i++)
		{
			num += n[i - 1];
		}
		num %= 10;
		int num2 = 0;
		for (int i = 7; i <= 12; i++)
		{
			num2 += n[i - 1];
		}
		num2 %= 10;
		int num3 = 0;
		for (int i = 13; i <= 18; i++)
		{
			num3 += n[i - 1];
		}
		num3 %= 10;
		return num + num2 + num3;
	}

	public int toBJ28(int[] n)
	{
		int num = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num += n[i - 1];
		}
		num %= 10;
		int num2 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 %= 10;
		int num3 = 0;
		for (int i = 4; i <= 19; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 %= 10;
		return num + num2 + num3;
	}

	public int toBJ16(int[] n)
	{
		int num = 0;
		for (int i = 1; i <= 16; i += 3)
		{
			num += n[i - 1];
		}
		num = num % 6 + 1;
		int num2 = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 = num2 % 6 + 1;
		int num3 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 = num3 % 6 + 1;
		return num + num2 + num3;
	}

	public string toBJ36ZN(int[] n)
	{
		int num = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num += n[i - 1];
		}
		num %= 10;
		int num2 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 %= 10;
		int num3 = 0;
		for (int i = 4; i <= 19; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 %= 10;
		string result = "";
		if (num == num2 && num2 == num3)
		{
			result = "豹子";
		}
		else if (num == num2 || num2 == num3 || num == num3)
		{
			result = "对子";
		}
		else
		{
			int[] array = new int[3]
			{
				num,
				num2,
				num3
			};
			Array.Sort(array);
			if (array[0] - array[1] == -1 && array[1] - array[2] == -1)
			{
				result = "顺子";
			}
			else if (array[0] == 0 && array[1] == 8 && array[2] == 9)
			{
				result = "顺子";
			}
			else if (array[0] == 0 && array[1] == 1 && array[2] == 9)
			{
				result = "顺子";
			}
			else if (array[0] - array[1] == -1 && array[1] - array[2] != -1)
			{
				result = "半顺";
			}
			else if (array[0] == 0 && array[2] == 9)
			{
				result = "半顺";
			}
			else if (array[1] - array[2] == -1 && array[0] - array[1] != -1)
			{
				result = "半顺";
			}
			else if (array[1] - array[2] != -1 && array[0] - array[1] != -1)
			{
				result = "杂六";
			}
		}
		return result;
	}

	public int toBJ36(int[] n)
	{
		int num = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num += n[i - 1];
		}
		num %= 10;
		int num2 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 %= 10;
		int num3 = 0;
		for (int i = 4; i <= 19; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 %= 10;
		int result = 0;
		if (num == num2 && num2 == num3)
		{
			result = 0;
		}
		else if (num == num2 || num2 == num3 || num == num3)
		{
			result = 1;
		}
		else
		{
			int[] array = new int[3]
			{
				num,
				num2,
				num3
			};
			Array.Sort(array);
			if (array[0] - array[1] == -1 && array[1] - array[2] == -1)
			{
				result = 2;
			}
			else if (array[0] == 0 && array[1] == 8 && array[2] == 9)
			{
				result = 2;
			}
			else if (array[0] == 0 && array[1] == 1 && array[2] == 9)
			{
				result = 2;
			}
			else if (array[0] - array[1] == -1 && array[1] - array[2] != -1)
			{
				result = 3;
			}
			else if (array[0] == 0 && array[2] == 9)
			{
				result = 3;
			}
			else if (array[1] - array[2] == -1 && array[0] - array[1] != -1)
			{
				result = 3;
			}
			else if (array[1] - array[2] != -1 && array[0] - array[1] != -1)
			{
				result = 4;
			}
		}
		return result;
	}

	public int toJND28(int[] n)
	{
		int num = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num += n[i - 1];
		}
		num %= 10;
		int num2 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 %= 10;
		int num3 = 0;
		for (int i = 4; i <= 19; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 %= 10;
		return num + num2 + num3;
	}

	public int toJND16(int[] n)
	{
		int num = 0;
		for (int i = 1; i <= 16; i += 3)
		{
			num += n[i - 1];
		}
		num = num % 6 + 1;
		int num2 = 0;
		for (int i = 2; i <= 17; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 = num2 % 6 + 1;
		int num3 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num3 += n[i - 1];
		}
		num3 = num3 % 6 + 1;
		return num + num2 + num3;
	}

	public int toJND11(int[] n)
	{
		int num = 0;
		for (int i = 1; i <= 16; i += 3)
		{
			num += n[i - 1];
		}
		num = num % 6 + 1;
		int num2 = 0;
		for (int i = 3; i <= 18; i += 3)
		{
			num2 += n[i - 1];
		}
		num2 = num2 % 6 + 1;
		return num + num2;
	}

	public int toPK10GJ(int[] n)
	{
		return n[0];
	}

	public int toPK10QH(int[] n, int qiHao)
	{
		if (qiHao % 10 == 0)
		{
			return n[9];
		}
		return n[qiHao % 10 - 1];
	}

	public int toPK22GJ(int[] n)
	{
		return n[0] + n[1] + n[2];
	}
}
