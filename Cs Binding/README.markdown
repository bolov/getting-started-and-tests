# C# binding


Different ways to bind target - source

## (1) Object created in code

Most online turorials create an object in xaml
This shows how to bind to an object created in the code

https://stackoverflow.com/questions/19981966/wpf-xaml-binding-to-object-created-in-code-behind

### Create instance

```c#
public class MainWindow : Window
{
    public Person Person1 { get; set; } = new Person("Nobody1");
    ...
}
```

### Set data context

```c#
   this.DataContext = this;
// ^~~~               ^~~~~
// target             source
```

### Bind

```xaml
Text="{Binding Path=Person1.PersonName}"
```


## (2) Object created in XAML resources

### Create Instance

```XAML
<Window.Resources>
    <local:Person x:Key="Person2" PersonName="Nobody 2"/>
</Window.Resources>
```

### Set data context and bind

```XAML
Text="{Binding Source={StaticResource Person2}, Path=PersonName}"
```

### Get instance

```c#
Person2 = FindResource("Person2") as Person;
```



## (3) Object created in XAML context

### Set context and create instance

to the object or a parent (even `window`):

```XAML
<Grid.DataContext>
    <local:Person/>
</Grid.DataContext>
```
### Bind

```XAML
Text="{Binding PersonName}"
```

### Get instance

```c#
Person3 = (FindName("Person3Text") as TextBlock).DataContext as Person;
```

