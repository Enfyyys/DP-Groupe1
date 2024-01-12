
 public interface Forme {
    double calculerAire();
    void dessiner();
}

public interface Rectangle {
    double calculerSurface();
    void tracerRectangle();
}


public class Adaptateur implements Forme {
    private Rectangle rectangle;

    public Adaptateur(Rectangle rectangle) {
        this.rectangle = rectangle;
    }

    @Override
    public double calculerAire() {
        return rectangle.calculerSurface();
    }

    @Override
    public void dessiner() {
        rectangle.tracerRectangle();
    }
}
