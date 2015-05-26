#MVVM III La vista (View)


En el [post](https://saturninopimentel.com/mvvm-ii-trabajando-con-atado-de-datos/) anterior hablamos de la característica de atado de datos de XAML y vimos que es la característica sobre la que está basado el patrón MVVM, en este post hablaremos del concepto de **vista (View)**, la vista es la parte de nuestra aplicación que trabaja de forma directa con los usuarios, es donde podremos dar formato a los datos para una mejor apreciación y en general crearemos nuestra experiencia de usuario que es tan importante hoy en día si queremos que nuestras aplicaciones triunfen.

La vista dentro de la implementación en los entornos XAML es activa es decir no es una vista que solo sea enviada por un controlador y que desconozca totalmente el funcionamiento de las otras secciones como son el **ViewModel** y el **Model** sino que contiene atado de datos, comportamientos (**Behaviors**) y eventos que trabajan en conjunto con el **Model** y con el **ViewModel**, lo cierto es que a pesar de esto la vista no es responsable de almacenar los estados de la información y esa tarea pasa a ser responsabilidad del **ViewModel**.

XAML tiene un conjunto de elementos que permiten crear experiencias de usuario muy elaboradas, a continuación veremos una descripción de los que a mi parecer son los más utilizados y que seguramente conocerás si ya tienes experiencia.

####Animaciones y transformaciones (Animations and Transformations)
Las animaciones hacen uso de **storyboards**, **timelines** y **keyframes** para permitirnos dar movimiento a los elementos dentro de nuestra interfaz de usuario, a continuación crearemos una animación sencilla en la cual moveremos un elemento **Ellipse** a través de nuestro **Grid**.

```language-csharp

	<Page.Resources>
    	<Storyboard x:Name="Motion"
    		Storyboard.TargetName="ellipse" AutoReverse="True" RepeatBehavior="Forever">
    		<DoubleAnimationUsingKeyFrames Storyboard.TargetName="ellipse" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)">
    			<EasingDoubleKeyFrame KeyTime="0" Value="0" />
    			<EasingDoubleKeyFrame KeyTime="0:0:1" Value="367.5" />
    			<EasingDoubleKeyFrame KeyTime="0:0:2" Value="786" />
    		</DoubleAnimationUsingKeyFrames>
    		<DoubleAnimationUsingKeyFrames Storyboard.TargetName="ellipse" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)">
    			<EasingDoubleKeyFrame KeyTime="0" Value="0" />
    			<EasingDoubleKeyFrame KeyTime="0:0:1" Value="282" />
    			<EasingDoubleKeyFrame KeyTime="0:0:2" Value="-31.5" />
    		</DoubleAnimationUsingKeyFrames>
    	</Storyboard>
    </Page.Resources>
```

Por otra parte las transformaciones nos permiten hacer cambios como rotar y simular espacios tridimensionales haciendo uso de las proyecciones. Como podrás ver en el siguiente ejemplo deformamos nuestro cuadrado haciendo uso de los ejes **X**, **Y**, **Z**. 

```language-csharp
<Page
    x:Class="DemoView.Transformations"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:DemoView"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    	<Rectangle Fill="#FFF4F4F5" HorizontalAlignment="Left" Height="349.816" Margin="231.954,130.3,0,0" Stroke="Black" VerticalAlignment="Top" Width="369.987" RenderTransformOrigin="0.5,0.5" UseLayoutRounding="False" d:LayoutRounding="Auto">
    		<Rectangle.Projection>
    			<PlaneProjection RotationX="130.239" RotationY="-40.848" RotationZ="-124.863" CenterOfRotationX="0.4" CenterOfRotationZ="25.6" GlobalOffsetZ="140" GlobalOffsetX="50" GlobalOffsetY="-39" LocalOffsetX="8" LocalOffsetY="12" LocalOffsetZ="-15"/>
    		</Rectangle.Projection>
    		<Rectangle.RenderTransform>
    			<CompositeTransform Rotation="-42.175" SkewY="-29.575" TranslateX="41.288" TranslateY="45.574"/>
    		</Rectangle.RenderTransform>
    		
    	</Rectangle>

    </Grid>
</Page>
```
 
####Behaviors
Los behaviors son los encargados de encapsular piezas de funcionalidad en un componente que podemos reutilizar posteriormente en los diversos objetos gráficos la idea de utilizar **behaviors** además de reutilizar es también tratar de reducir el code-behind, veamos el ejemplo siguiente en el cual al presionar nuestro elemento **Rectangle** este realizará una animación (un giro y una transición nada complicado).
```language-csharp
<Page x:Class="DemoView.Behaviors"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:Core="using:Microsoft.Xaml.Interactions.Core"
      xmlns:Interactivity="using:Microsoft.Xaml.Interactivity"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:local="using:DemoView"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      mc:Ignorable="d">
    <Page.Resources>
        <Storyboard x:Name="SizeChange">
            <DoubleAnimationUsingKeyFrames Storyboard.TargetName="rectangle" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)">
                <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                <EasingDoubleKeyFrame KeyTime="0:0:2" Value="691.045" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetName="rectangle" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)">
                <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                <EasingDoubleKeyFrame KeyTime="0:0:2" Value="226.866" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetName="rectangle" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.Rotation)">
                <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                <EasingDoubleKeyFrame KeyTime="0:0:2" Value="-181.374" />
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </Page.Resources>

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="120" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <Button x:Name="backButton"
                    Margin="39,59,39,0"
                    VerticalAlignment="Top"
                    AutomationProperties.AutomationId="BackButton"
                    AutomationProperties.ItemType="Navigation Button"
                    AutomationProperties.Name="Back"
                    Click="backButton_Click"
                    Command="{Binding NavigationHelper.GoBackCommand,
                                      ElementName=pageRoot}"
                    Style="{StaticResource NavigationBackButtonNormalStyle}" />
        </Grid>
        <Rectangle x:Name="rectangle"
                   Width="260"
                   Height="199"
                   Margin="266,255,0,0"
                   HorizontalAlignment="Left"
                   VerticalAlignment="Top"
                   Fill="#FFF4F4F5"
                   RenderTransformOrigin="0.5,0.5"
                   Stroke="Black">
            <Interactivity:Interaction.Behaviors>
                <Core:EventTriggerBehavior EventName="Tapped">
                    <Core:CallMethodAction MethodName="Begin" TargetObject="{Binding ElementName=SizeChange}" />
                </Core:EventTriggerBehavior>
            </Interactivity:Interaction.Behaviors>
            <Rectangle.RenderTransform>
                <CompositeTransform />
            </Rectangle.RenderTransform>
        </Rectangle>

    </Grid>
</Page>

```

####Resources
Los recursos son elementos que se pueden reutilizar para alterar la forma en que se visualizan los diversos controles disponibles, en estos recursos nosotros podemos definir **brushes** y **styles** que servirán para "vestir" nuestros controles. En el siguiente ejemplo definiremos un recurso para definir el color de nuestro control **Rectangle**.
```language-csharp
<Page
    x:Class="DemoView.Resources"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:DemoView"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
	<Page.Resources>
		<Color x:Key="WhiteKey">White</Color>
	</Page.Resources>

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    	<Rectangle HorizontalAlignment="Left" Height="260" Margin="82,158,0,0" Stroke="Black" VerticalAlignment="Top" Width="434">
    		<Rectangle.Fill>
    			<SolidColorBrush Color="{StaticResource WhiteKey}"/>
    		</Rectangle.Fill>
    	</Rectangle>

    </Grid>
</Page>

```
####Style, Templates y Themes
Los estilos **(Style)**, plantillas **(Templates)** y temas **(Themes)** son recursos que podemos reutilizar a lo largo de nuestro código XAML para dar uniformidad a nuestros controles. Como mencionamos en el punto anterior son formas de vestir a nuestros controles con la ventaja de que podemos declarar en un solo lugar como deberían verse nuestros controles a lo largo de nuestra aplicación, un equivalente de estos en el entorno web son los estilos **css**.

En el siguiente ejemplo declararemos algunos estilos que aplicaremos a los controles de tipo botón, como podrás notar hemos alterado uno de nuestros botones para tener una forma elíptica.

```language-csharp
<Page
    x:Class="DemoView.StylesPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:DemoView"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d" FontFamily="Global User Interface" Background="Black">
	<Page.Resources>
		<Style TargetType="Button">
			<Setter Property="BorderBrush" Value="#FFC8578B"/>
			<Setter Property="Background" Value="#FF40329D"/>
			<Setter Property="Foreground" Value="#FFEACDCD"/>		
		</Style>
		<ControlTemplate x:Key="ButtonTemplate" TargetType="Button">
		<Grid>
          <Ellipse Fill="{TemplateBinding Background}"/>
          <ContentPresenter HorizontalAlignment="Center"
                            VerticalAlignment="Center"/>
        </Grid>
		</ControlTemplate>
	</Page.Resources>

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    	<Button Content="Button" HorizontalAlignment="Left" Height="103" Margin="174,157,0,0" VerticalAlignment="Top" Width="276" />
		<Button Content="Segundo botón" Template="{StaticResource ButtonTemplate}" Height="97" Margin="177,300,0,371" Width="270"/>
    </Grid>
</Page>
```
####Blend
Todos los elementos arriba mencionados pueden ser escritos por los desarrolladores o los diseñadores en Visual Studio aunque siendo realistas se necesitan mucha más experiencia y conocimientos para llevarlo a cabo que cuando optas por utilizar una herramienta totalmente enfocada al diseño de tu interfaz de usuario como lo es **Blend** .

**Blend** si aún no lo conoces es la herramienta por excelencia para la creación de interfaces de usuario en XAML que además cuenta con la capacidad de crear datos falsos en base a clases para que puedas tener una referencia visual sin afectar el trabajo de otras personas en tu equipo de trabajo, **Blend** anteriormente tenía el nombre de Expression Blend y era un producto aparte, pero ahora viene incluido con Visual Studio.

Debo reconocer que pocas veces abandono Visual Studio en cuestiones de desarrollo, la verdad es que me siento muy cómodo en él, solo lo abandono cuando necesito trabajar con la interfaz de usuario, ya que para eso es mucho más fácil trabajar con **Blend**.

En lo personal cuando hablamos de aplicaciones empresariales prefiero dar un enfoque orientado al contenido (una o dos animaciones para darle alegría al proyecto :D), aunque XAML te permite generar interfaces de usuario muy potentes y con un esfuerzo mínimo, ¿Tú que tipo de interfaces de usuario prefieres?
 
Si deseas descargar los ejemplos puedes hacerlo desde  [github](https://github.com/Satur01/MVVMLaVista), te invito a leer los posts anteriores de esta serie [MVVM II "Trabajando con atado de datos"](https://saturninopimentel.com/mvvm-ii-trabajando-con-atado-de-datos/) y [MVVM I "un poco de historia"](https://saturninopimentel.com/mvvm-i-un-poco-de-historia/).
