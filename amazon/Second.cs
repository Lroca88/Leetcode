using System.Collections.Generic;

class Second {
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
	public int checkWinner(List<List<string>> codeList, List<string> shoppingCart)
	{
        int cartIndex = 0;

		foreach(var list in codeList) {
            foreach(var item in list){
                if (item == "anything") cartIndex++;
                if (item == shoppingCart[cartIndex]) cartIndex++;
            }
        }

        return cartIndex == shoppingCart.Count ? 1 : 0;
	}
	// METHOD SIGNATURE ENDS
}