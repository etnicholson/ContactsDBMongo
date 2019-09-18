describe('Login as a Admin', function() {
    it('should login and retrive a person', function() {
      browser.get('http://localhost:4200/');
      element(by.name('email')).sendKeys('admin@admin.com');
      element(by.name('password')).sendKeys('test');  
      element(by.id('loginButton')).click();  
      element(by.name('searchString')).sendKeys('1111111111');  
      let t = element(by.id('personName')).getAttribute('value');
      expect(t).toEqual('testing');
  

      browser.pause();  
    });
  });

  