describe('Checkout Flow', () => {
  it('should place an order', () => {
    cy.visit('/products');
    cy.contains('Add to Cart').first().click();
    cy.visit('/cart');
    cy.contains('Checkout').click();

    cy.get('input[placeholder="Enter your full name"]').type('Deepika SM');
    cy.get('input[placeholder="Enter your email"]').type('deepika@example.com');
    cy.get('textarea').type('Coimbatore');
    cy.get('input[placeholder="Enter city"]').type('Coimbatore');
    cy.get('input[placeholder="Enter zip"]').type('641001');

    cy.contains('Place Order').click();
    cy.contains('Order placed successfully!').should('exist');
  });
});
