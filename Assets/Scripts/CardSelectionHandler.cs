using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler
{
    [SerializeField] private float _verticalMoveAmount = 30f;
    [SerializeField] private float _moveTime = 0.1f;
    [Range(0f, 2f), SerializeField] private float _scaleAmount = 1.1f;

    private Vector3 _startPos;
    private Vector3 _startScale;
    private bool isClicked = false;

    public BattleSystem battleSystem;

    private void Start()
    {
        _startPos = transform.position;
        _startPos.y = -3.5f;
        _startScale = transform.localScale;
        battleSystem = FindObjectOfType<BattleSystem>();

    }

    private IEnumerator MoveCard(bool startAnimation, Vector3 targetPosition)
    {
        Vector3 endPosition;
        Vector3 endScale;

        float elapsedTime = 0f;


        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            while (elapsedTime < _moveTime)
            {
                elapsedTime += Time.deltaTime;

                if (startAnimation)
                {
                    endPosition = targetPosition != Vector3.zero ? targetPosition : _startPos + new Vector3(0f, _verticalMoveAmount, 0f);
                    endScale = _startScale * _scaleAmount;
                    gameObject.transform.SetAsLastSibling();
                }
                else
                {
                    endPosition = _startPos;
                    endScale = _startScale;
                }

                // Calcular la cantidad interpolada
                Vector3 lerpedPos = Vector3.Lerp(transform.position, endPosition, (elapsedTime / _moveTime));
                Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, (elapsedTime / _moveTime));

                // Aplicar cambios a posición y escala
                transform.position = lerpedPos;
                transform.localScale = lerpedScale;

                yield return null;
            }
        }
    }

    private IEnumerator MoveCardInstant(bool startAnimation, Vector3 targetPosition)
    {
        Vector3 endPosition;
        Vector3 endScale;

        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            if (startAnimation)
            {
                endPosition = targetPosition != Vector3.zero ? targetPosition : _startPos + new Vector3(0f, _verticalMoveAmount, 0f);
                endScale = _startScale * _scaleAmount;
                gameObject.transform.SetAsLastSibling();
                yield return new WaitForSeconds(1);
                endScale = _startScale;
            }
            else
            {
                endPosition = _startPos;
                endScale = _startScale;
            }

            // Aplicar cambios a posición y escala instantáneamente
            transform.position = endPosition;
            transform.localScale = endScale;
        }
        yield return null;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        // Seleccionar la carta
        eventData.selectedObject = gameObject;
        _startPos = transform.position;
        _startPos.y = -3.5f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Deseleccionar la carta
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
            if (!isClicked)
        {
            StartCoroutine(MoveCard(true, Vector3.zero));
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!isClicked)
        {
            StartCoroutine(MoveCard(false, Vector3.zero));
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Mover la carta a una posición específica al hacer clic
        if (!isClicked)
        {
            isClicked = true;
            StartCoroutine(MoveCardInstant(true, new Vector3(3, -8, 0)));
        }
        else
        {
            isClicked = false;
            StartCoroutine(MoveCard(false, Vector3.zero));
        }
    }
}
